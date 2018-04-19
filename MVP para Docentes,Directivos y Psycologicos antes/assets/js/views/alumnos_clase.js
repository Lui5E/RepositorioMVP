function openCont(evt, contName) {
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

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(contName).style.display = "inline";
    evt.currentTarget.className += " active";
}



function abrirContexto(evt, nombreContexto) {
    // Declare all variables
    var i, tabconten2, tablinks2;

    // Get all elements with class="tabcontent" and hide them
    tabcontent2 = document.getElementsByClassName("tabcontent2");
    for (i = 0; i < tabcontent2.length; i++) {
        tabcontent2[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks2 = document.getElementsByClassName("tablinks2");
    for (i = 0; i < tablinks2.length; i++) {
        tablinks2[i].className = tablinks2[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the link that opened the tab
    document.getElementById(nombreContexto).style.display = "block";
    evt.currentTarget.className += " active";
}
