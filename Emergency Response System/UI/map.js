using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emergency_Response_System.UI
{
        class map
        {
            var map = L.map('map').setView([31.5497, 74.3436], 12);

            // Add tiles
            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                maxZoom: 19
            }).addTo(map);

            // Handle clicks
            map.on('click', function (e) {
                var payload = {
                    latitude: e.latlng.lat,
                    longitude: e.latlng.lng
                };
                window.chrome.webview.postMessage(JSON.stringify(payload));
            });

            // Utilities
            function addMarker(lat, lng, label) {
                L.marker([lat, lng]).addTo(map).bindPopup(label);
            }

            function drawCoverage(lat, lng, kmRadius) {
                L.circle([lat, lng], {
                    radius: kmRadius * 1000,
                    color: 'blue',
                    fillOpacity: 0.1
                }).addTo(map);
            }

            function centerOn(lat, lng) {
                map.setView([lat, lng], 14);
            }
      }
}
