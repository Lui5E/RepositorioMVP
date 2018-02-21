function openCity(evt, cityName) {
    // Declare all variables

    document.getElementById("contenedor_grupos").style.display = "none";
    document.getElementById("alumno").style.display = "block";
    document.getElementById("alumno").style.padding =  ".1em 0 1em 0";
    document.getElementById("contenedor_profesores").style.display = "none";
    document.getElementById("grupos_profesores").style.display = "none";
}

function openGroup(evt, cityName) {
    // Declare all variables

    document.getElementById("contenedor_grupos").style.display = "block";
    document.getElementById("alumno").style.display = "none";
    document.getElementById("contenedor_profesores").style.display = "none";
    document.getElementById("grupos_profesores").style.display = "none";

}

function Grupos(evt, cityName) {
    // Declare all variables

    document.getElementById("contenedor_grupos").style.display = "block";
    document.getElementById("alumno").style.display = "none";
    document.getElementById("contenedor_profesores").style.display = "none";
    document.getElementById("grupos_profesores").style.display = "none";
}

function Profesores(evt, cityName) {
    // Declare all variables

    document.getElementById("contenedor_profesores").style.display = "block";
    document.getElementById("alumno").style.display = "none";
    document.getElementById("contenedor_grupos").style.display = "none";
    document.getElementById("grupos_profesores").style.display = "none";
}

function tres() {
    // Declare all variables

    document.getElementById("contenedor_profesores").style.display = "none";
    document.getElementById("alumno").style.display = "none";
    document.getElementById("contenedor_grupos").style.display = "none";
    document.getElementById("grupos_profesores").style.display = "block";
}
