function openCity(evt, cityName) {
    // Declare all variables

    document.getElementById("contenedor_grupos").style.display = "none";
    document.getElementById("alumno").style.display = "block";
}

function openGroup(evt, cityName) {
    // Declare all variables

    document.getElementById("contenedor_grupos").style.display = "block";
    document.getElementById("alumno").style.display = "none";
}
