/*window.onload = function () {
   alert("cargado...");
}*/
//--Menu lateral Tab--//
function abrirContexto(evt, nombreContexto) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the link that opened the tab
    document.getElementById(nombreContexto).style.display = "inline";
    evt.currentTarget.className += " active";
}
//---Respuestas contexto---//
function Con(evt, cityName) {
    // Declare all variables
    var i, tabcontentCon, tablinksCon;

    // Get all elements with class="tabcontent" and hide them
    tabcontentCon = document.getElementsByClassName("tabcontentCon");
    for (i = 0; i < tabcontentCon.length; i++) {
        tabcontentCon[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinksCon = document.getElementsByClassName("tablinksCon");
    for (i = 0; i < tablinksCon.length; i++) {
        tablinksCon[i].className = tablinksCon[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}

// &&&&
//Inicio contexto ACTIVIDADES
//Grafica Positivo PANAS
var ctx = document.getElementById("ACTpositivePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Decidido", "Atento", "Entusiasmado", "Activo", "Inspirado", "Entusiasmado", "Orgulloso", "Alerta", "Interesado", "Enérgetico"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [9.9, 6, 1.5, 3, 8, 5, 4.4, 7.5, 4.3, 5.7],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo PANAS
var ctx = document.getElementById("ACTnegativePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Atemorizado", "Miedoso", "Nervioso", "Asustado", "Irritable", "Tenso", "Culpable", "Disgustado", "Avergonzado", "Hostil"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 8, 2, 3, 1.5, 3.5, 5, 7],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//
var ctx = document.getElementById("ACTpositiveAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Contemplación", "Felicidad", "Neutral", "Sorpresa"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [5, 8.8, 2.3, 6],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo API
var ctx = document.getElementById("ACTnegativeAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Enojo", "Disgusto", "Miedo", "Tristeza"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [0.01, 0.2, 1, 0.9],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//FIN contexto ACTIVIDADES

/////

//Inicio contexto COMPAÑEROS
//Grafica Positivo PANAS
var ctx = document.getElementById("COMPANEROSpositivePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Decidido", "Atento", "Entusiasmado", "Activo", "Inspirado", "Entusiasmado", "Orgulloso", "Alerta", "Interesado", "Enérgetico"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [4, 6, 0.5, 3, 7.9, 2, 3.9, 7.5, 4.3, 5.5],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo PANAS
var ctx = document.getElementById("COMPANEROSnegativePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Atemorizado", "Miedoso", "Nervioso", "Asustado", "Irritable", "Tenso", "Culpable", "Disgustado", "Avergonzado", "Hostil"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [7.8, 7, 3.5, 4, 2.6, 1.7, 6.99, 0.2, 8.8, 2],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//
var ctx = document.getElementById("COMPANEROSpositiveAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Contemplación", "Felicidad", "Neutral", "Sorpresa"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [3.7, 2.9, 8.9, 6.1],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo API
var ctx = document.getElementById("COMPANEROSnegativeAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Enojo", "Disgusto", "Miedo", "Tristeza"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [0.5, 2.5, 7.2, 2.09],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//FIN contexto COMPAÑEROS

//////

//Inicio contexto PROFESORES
//Grafica Positivo PANAS
var ctx = document.getElementById("PROFESORESpositivePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Decidido", "Atento", "Entusiasmado", "Activo", "Inspirado", "Entusiasmado", "Orgulloso", "Alerta", "Interesado", "Enérgetico"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [3, 6, 2.5, 3, 8, 2.2, 0.4, 4.4, 0.01, 5],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo PANAS
var ctx = document.getElementById("PROFESORESnegativePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Atemorizado", "Miedoso", "Nervioso", "Asustado", "Irritable", "Tenso", "Culpable", "Disgustado", "Avergonzado", "Hostil"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 7, 5.2, 70, 2, 3.4, 1.5, 3, 5, 9],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//
var ctx = document.getElementById("PROFESORESpositiveAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Contemplación", "Felicidad", "Neutral", "Sorpresa"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [4.7, 6.8, 5.7, 7.8, 7],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo API
var ctx = document.getElementById("PROFESORESnegativeAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Enojo", "Disgusto", "Miedo", "Tristeza"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 8],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//FIN contexto PROFESORES

//////

//Inicio contexto AMIGOS
//Grafica Positivo PANAS
var ctx = document.getElementById("AMIGOSpositivePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Decidido", "Atento", "Entusiasmado", "Activo", "Inspirado", "Entusiasmado", "Orgulloso", "Alerta", "Interesado", "Enérgetico"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [2.6, 6, 1.5, 8, 6.8, 2.1, 4.4, 7.5, 4.3, 7],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo PANAS
var ctx = document.getElementById("AMIGOSnegativePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Atemorizado", "Miedoso", "Nervioso", "Asustado", "Irritable", "Tenso", "Culpable", "Disgustado", "Avergonzado", "Hostil"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 8, 2, 3, 1.5, 2.4, 4.5, 4.9],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//
var ctx = document.getElementById("AMIGOSpositiveAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Contemplación", "Felicidad", "Neutral", "Sorpresa"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [3.7, 6.8, 4.5, 8, 7],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo API
var ctx = document.getElementById("AMIGOSnegativeAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Enojo", "Disgusto", "Miedo", "Tristeza"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 7.6],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//FIN contexto AMIGOS

//////

//Inicio contexto FAMILIA
//Grafica Positivo PANAS
var ctx = document.getElementById("FAMILIApositivePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Decidido", "Atento", "Entusiasmado", "Activo", "Inspirado", "Entusiasmado", "Orgulloso", "Alerta", "Interesado", "Enérgetico"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [3, 6, 1.5, 3, 8, 2, 3.6, 7.5, 4.3, 5.6],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo PANAS
var ctx = document.getElementById("FAMILIAnegativePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Atemorizado", "Miedoso", "Nervioso", "Asustado", "Irritable", "Tenso", "Culpable", "Disgustado", "Avergonzado", "Hostil"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 8, 2, 3, 1.5, 3, 5.3, 4],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//
var ctx = document.getElementById("FAMILIApositiveAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Contemplación", "Felicidad", "Neutral", "Sorpresa"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [3.7, 6.8, 4.5, .01, 7],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo API
var ctx = document.getElementById("FAMILIAnegativeAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Enojo", "Disgusto", "Miedo", "Tristeza"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 8],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//FIN contexto FAMILIA

//////

//Inicio contexto TAREA
//Grafica Positivo PANAS
var ctx = document.getElementById("TAREApositivePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Decidido", "Atento", "Entusiasmado", "Activo", "Inspirado", "Entusiasmado", "Orgulloso", "Alerta", "Interesado", "Enérgetico"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [7, 4.4, 1.7, 3.3, 8, 2, 3, 2.5, 4.3, 5.5],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo PANAS
var ctx = document.getElementById("TAREAnegativePANASChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Atemorizado", "Miedoso", "Nervioso", "Asustado", "Irritable", "Tenso", "Culpable", "Disgustado", "Avergonzado", "Hostil"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 8, 2, 3, 1.5, 6.3, 2.1, 4],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//
var ctx = document.getElementById("TAREApositiveAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Contemplación", "Felicidad", "Neutral", "Sorpresa"],
        datasets: [{
            label: 'Emociones Positivas',
            data: [3.7, 6.8, 4.5, 8, 7],
            backgroundColor: [
                'rgba(54, 162, 235, 0.2)'
            ],
            borderColor: [
                'rgba(54, 162, 235, 1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//Grafica Negativo API
var ctx = document.getElementById("TAREAnegativeAPIChart").getContext('2d');
var positiveChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["Enojo", "Disgusto", "Miedo", "Tristeza"],
        datasets: [{
            label: 'Emeciones Negativas',
            data: [8, 3.5, 3.3, 8],
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)'
            ],
            borderColor: [
                'rgba(255,99,132,1)'
            ],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero:true
                }
            }]
        }
    }
});
//FIN contexto TAREA

//////
