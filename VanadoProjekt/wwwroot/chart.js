let mojGraf = null;
function crtajMojGraf(divId, labels, points) {
    const ctx = document.getElementById(divId).getContext('2d');

    if (mojGraf) {
        mojGraf.destroy();
    }

    mojGraf = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Kvarovi kroz vrijeme',
                data: points.map(p => ({ x: p.x, y: p.y })),
                borderColor: 'blue',
                backgroundColor: 'rgba(0,0,255,0.1)',
                stepped: true,
                fill: true,
                tension: 0
            }]
        },
        options: {
            parsing: false,
            scales: {
                x: {
                    min: 0,
                    max: 100,
                    type: 'linear',
                    ticks: {
                        stepSize: 1,
                        callback: function (value) {
                            return;
                        }
                    },
                    title: { display: true, text: 'Vrijeme' }
                },
                y: {
                    type: 'linear',
                    min: 0,
                    max: 1,
                    ticks: {
                        stepSize: 1,
                        callback: function (value) {
                            return value === 0 ? 'NEAKTIVAN' : 'AKTIVAN';
                        }
                    },
                    title: { display: true, text: '' }
                }
            }
        }
    });
}