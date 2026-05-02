using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Emergency_Response_System.BL;
using Emergency_Response_System.BL.Emergency_Response_System.BL;
using Emergency_Response_System.DL;
using Emergency_Response_System.Helpers;
using Emergency_Response_System.Managers;

namespace Emergency_Response_System.UI
{
    public partial class PickFastestAmbulance : Form
    {
        CityGraph cityGraph = new CityGraph();

        public PickFastestAmbulance()
        {
            InitializeComponent();
            LoadIntersections();
            LoadCurrentAssignments(); // ✅ load grid on form open
        }

        public void LoadIntersections()
        {
            cmbId.Items.Clear();
            cmbSeverity.Items.Clear();

            foreach (var inter in IntersectionDL.GetAllIntersections())
            {
                cityGraph.AddIntersection(inter.Id, inter.Name);
                cmbId.Items.Add($"{inter.Id} - {inter.Name}");
            }

            foreach (var road in RoadDL.GetAllRoads())
            {
                cityGraph.AddBidirectionalRoad(road.FromIntersectionId, road.ToIntersectionId, road.TravelTimeMinutes);
            }
        }

        private void btnFindFastestAmbulance_Click(object sender, EventArgs e)
        {
            try
            {
                AmbulanceLinkedList list = new AmbulanceLinkedList();
                foreach (var amb in AmbulanceDL.GetAllAmbulances())
                {
                    list.Add(amb);
                }
                if (cmbId.SelectedItem == null)
                {
                    MessageBox.Show("Please select an intersection.");
                    return;
                }
                string selected = cmbId.SelectedItem.ToString();
                int emergencyIntersection = Convert.ToInt32(selected.Split('-')[0].Trim());

                if (cmbSeverity.SelectedItem == null)
                {
                    MessageBox.Show("Please select severity.");
                    return;
                }

                EmergencyBL emergency = new EmergencyBL
                {
                    intersection_id = emergencyIntersection,
                    severity = cmbSeverity.SelectedItem.ToString()
                };
                int newEmergencyId = EmergencyDL.AddEmergency(emergency);
                emergency.emergency_id = newEmergencyId;

                AmbulanceBL[] ambulances = list.ToArrayManual();

                for (int i = 0; i < ambulances.Length; i++)
                {
                    int startIntersection = StationDL.GetIntersectionIdByStation(ambulances[i].station_id);
                    int endIntersection = emergency.intersection_id;

                    double routeTime = GraphAlgorithms.FindFastestRoute(
                        cityGraph,
                        cityGraph.GetIndexById(startIntersection),
                        cityGraph.GetIndexById(endIntersection)
                    );
                    if (routeTime <= 0 || double.IsInfinity(routeTime))
                    {
                        ambulances[i].EtaMinutes = int.MaxValue;
                    }
                    else
                    {
                        ambulances[i].EtaMinutes = (int)Math.Round(routeTime);
                    }
                }

                SortManager.QuickSortAmbulances(ambulances, 0, ambulances.Length - 1);

                AmbulanceBL fastest = ambulances.FirstOrDefault(a =>
                    a.status.Equals("Available", StringComparison.OrdinalIgnoreCase) &&
                    a.EtaMinutes != int.MaxValue);

                if (fastest != null)
                {
                    fastest.status = "Assigned";
                    AmbulanceDL.AssignedAmbulance(fastest);

                    int etaMinutes = fastest.EtaMinutes;

                    var log = new DispatchBL
                    {
                        EmergencyId = emergency.emergency_id,
                        AmbulanceId = fastest.ambulance_id,
                        EtaMinutes = etaMinutes,
                        ArrivalTime = null,
                        AssignedAt = DateTime.Now,   
                        Status = "Assigned"        
                    };


                    int newDispatchId = DispatchDL.AddDispatch(log);
                    log.DispatchId = newDispatchId;

                    if (etaMinutes == int.MaxValue)
                    {
                        MessageBox.Show($"Ambulance {fastest.plate_number} dispatched, but route is unreachable.");
                    }
                    else
                    {
                        MessageBox.Show($"Ambulance {fastest.plate_number} dispatched. ETA: {etaMinutes} minutes.");
                    }

                    LoadCurrentAssignments();
                }
                else
                {
                    MessageBox.Show("No available ambulances found with a valid route.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DispatchDL.UndoLastDispatch();
            MessageBox.Show("Last dispatch has been undone.");
            LoadCurrentAssignments(); 
        }

        private void LoadCurrentAssignments()
        {
            var assignments = DispatchDL.GetAllDispatches();
            dgvDispatches.DataSource = null;
            dgvDispatches.DataSource = assignments.ToList();
        }


        private void PickFastestAmbulance_Load(object sender, EventArgs e)
        {
            cmbSeverity.Items.Clear();
            cmbSeverity.Items.Add("Critical");
            cmbSeverity.Items.Add("High");
            cmbSeverity.Items.Add("Medium");
            cmbSeverity.Items.Add("Low");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new Admin_Dashboard();
            form.ShowDialog();
        }
    }
}
