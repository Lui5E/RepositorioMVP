<?php
  include('header.php');
  if(isset($_GET['Grupo']) && isset($_SESSION['trabajador']))
  {
    $grado = $_GET['Grupo'][0];
    $grupo = $_GET['Grupo'][1];
  }
  else
  {
    header('Location: index_docente.php');
  }

  //Conexión a BD
  try{
    $conn = new mysqli('localhost', 'root', '', 'bilbo');
		if(!$conn->connect_error)
    {
      $sql = "
          select
            *
          from
            alumnos
          where
            alumno_grado = '".$grado."'
					  and alumno_grupo = '".$grupo."'";
			$sql_respuesta = $conn->query($sql);
      if($sql_respuesta)
      {
        //echo "Consulta exitosa";
      }
      else
      {
        //echo "Balla no hay ningun alumno en esta clase o.O";
      }
    }
    else
    {
 		 echo "Error al conectar a la BD";
 	  }
  } catch (Exception $e){}
 ?>


 <div class="container">
   <div id="clase">
     <h1>Clase <?php echo($_GET['Grupo']); ?></h1>
   </div>
   <?php if(($sql_respuesta->num_rows) > 0): ?>
     <h2>Se encontraron 10<!--<?php //echo($sql_respuesta->num_rows); ?>--> alumnos en esta clase</h2>
   <?php endif; ?>
   <?php if($sql_respuesta->num_rows == 0): ?>
     <h1>No se han agregado alumnos ha esta clase</h1>
   <?php endif; ?>


   <div class="menu-clase tab">
     <button class="tablinks" onclick="openCont(event, 'Alumnos')">Alumnos</button>
     <button class="tablinks" onclick="openCont(event, 'General')">Estadísticas Generales</button>
   </div>
   <div class="col-container">
     <div class="izquierda col">
       <div class="">
         <div class="circulo verde">
         </div>
          <h4>(5)</h4>
       </div>
       <div class="">
         <div class="circulo amarillo">
         </div>
          <h4>(3)</h4>
        </div>
       <div class="">
         <div class="circulo rojo">
         </div>
         <h4>(2)</h4>
       </div>
     </div>
     <div id="Alumnos" class="contenido-clase col tabcontent">
       <?php
          while($row = $sql_respuesta->fetch_assoc()):
       ?>
       <div class="alumno col-md-3">
         <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot verde"></span></span></h1>
         <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=".$row['alumno_id']."'>".$row['alumno_nombre']."</a>"; ?></h3>
       </div>
       <?php
          endwhile;
        ?>
        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot verde"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Alonso Navarro Rubén</a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot amarillo"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Víctor Hugo Alejo Guerrero</a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot verde"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Alberto Pérez Arbea</a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot rojo"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Socorro Arias Rodríguez</a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot amarillo"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Javier Leonardo Viñas Ovalle</a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot verde"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Matilde Basaldúa Ramírez</a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot amarillo"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Alfredo Flores Barrera </a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot verde"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Miguel Ángel Vázquez Torres</a>"; ?></h3>
        </div>

        <div class="alumno col-md-3">
          <h1 style="text-align: center;"><span class="glyphicon glyphicon-user" aria-hidden="true"><span class="dot rojo"></span></span></h1>
          <h3 style="text-align: center;"><?php echo "<a href='ver_alumno.php?ID=1'>Marisol Castañeda Pérez</a>"; ?></h3>
        </div>
     </div>

     <!--    ////////////////////////////////////////////////////////
     ///////////////////////////////////////////////////////////////
                          General-->
     <div id="General" class="tabcontent">
       <h2 class="centrar">Seleccione un contexto</h2>

       <div class="container col-container">
         <!--Prueba tabulación vertical-->
         <div id="opciones" class="tab">
           <button class="tablinks2" onclick="abrirContexto(event, 'Actividades')">Actividades</button>
           <button class="tablinks2" onclick="abrirContexto(event, 'Compañeros')">Compañeros</button>
           <button class="tablinks2" onclick="abrirContexto(event, 'Profesores')">Profesores</button>
           <button class="tablinks2" onclick="abrirContexto(event, 'Amigos')">Amigos</button>
           <button class="tablinks2" onclick="abrirContexto(event, 'Familia')">Familia</button>
           <button class="tablinks2" onclick="abrirContexto(event, 'Tarea')">Tarea</button>
         </div>
         <div id="Actividades" class="tabcontent2 " style="display: block;">
           <h3 class="centrar">Actividades extracurriculares</h3>
           <div class="resultados">
             <div class="row">
               <table>
                 <tr>
                   <th rowspan="2">Alumno</th>
                   <th colspan="2">Resultados de Cuestionario de Afectividad Positiva y Negativa</th>
                   <th colspan="2">Resultados del Análisis de Expresiones Faciales</th>
                 </tr>
                 <tr>
                   <th>Promedio de afectividad positiva</th>
                   <th>Promedio de afectividad negativa</th>
                   <th>Promedio de afectividad positiva</th>
                   <th>Promedio de afectividad negativa</th>
                 </tr>
                <tr>
                  <td>Luis Enrique Rangel Delgado</td>
                  <td>4.2</td>
                  <td>2.3</td>
                  <td>3.8</td>
                  <td>3.5</td>
                </tr>
                <tr>
                  <td>Alonso Navarro Rubén</td>
                  <td>2.3</td>
                  <td>4.1</td>
                  <td>3.1</td>
                  <td>4</td>
                </tr>
                <tr>
                  <td>Víctor Hugo Alejo Guerrero</td>
                  <td>4.5</td>
                  <td>4</td>
                  <td>4.2</td>
                  <td>3.4</td>
                </tr>
                <tr>
                  <td>Alberto Pérez Arbea</td>
                  <td>2.9</td>
                  <td>3.5</td>
                  <td>4.8</td>
                  <td>3.6</td>
                </tr>
                <tr>
                  <td>Socorro Arias Rodríguez</td>
                  <td>4.2</td>
                  <td>2.3</td>
                  <td>3.8</td>
                  <td>3.5</td>
                </tr>
                <tr>
                  <td>Javier Leonardo Viñas Ovalle</td>
                  <td>4.3</td>
                  <td>4.6</td>
                  <td>2.4</td>
                  <td>4.4</td>
                </tr>
                <tr>
                  <td>Matilde Basaldúa Ramírez</td>
                  <td>3.6</td>
                  <td>4.1</td>
                  <td>4.2</td>
                  <td>3.4</td>
                </tr>
                <tr>
                  <td>Alfredo Flores Barrera</td>
                  <td>3.8</td>
                  <td>3.2</td>
                  <td>4</td>
                  <td>3.6</td>
                </tr>
                <tr>
                  <td>Miguel Ángel Vázquez Torres</td>
                  <td>4.9</td>
                  <td>1.5</td>
                  <td>4.5</td>
                  <td>3.4</td>
                </tr>
                <tr>
                  <td>Marisol Castañeda Pérez</td>
                  <td>3.9</td>
                  <td>2.5</td>
                  <td>4.5</td>
                  <td>3.4</td>
                </tr>
              </table>
             </div>
          </div>
        </div>

         <div id="Compañeros" class="tabcontent2 "  style="display: none;">
           <h3 class="centrar">Compañeros</h3>
           <div class="row">
             <table>
               <tr>
                 <th rowspan="2">Alumno</th>
                 <th colspan="2">Resultados de Cuestionario de Afectividad Positiva y Negativa</th>
                 <th colspan="2">Resultados del Análisis de Expresiones Faciales</th>
               </tr>
               <tr>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
               </tr>
              <tr>
                <td>Luis Enrique Rangel Delgado</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Alonso Navarro Rubén</td>
                <td>2.3</td>
                <td>4.1</td>
                <td>3.1</td>
                <td>4</td>
              </tr>
              <tr>
                <td>Víctor Hugo Alejo Guerrero</td>
                <td>4.5</td>
                <td>4</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alberto Pérez Arbea</td>
                <td>2.9</td>
                <td>3.5</td>
                <td>4.8</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Socorro Arias Rodríguez</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Javier Leonardo Viñas Ovalle</td>
                <td>4.3</td>
                <td>4.6</td>
                <td>2.4</td>
                <td>4.4</td>
              </tr>
              <tr>
                <td>Matilde Basaldúa Ramírez</td>
                <td>3.6</td>
                <td>4.1</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alfredo Flores Barrera</td>
                <td>3.8</td>
                <td>3.2</td>
                <td>4</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Miguel Ángel Vázquez Torres</td>
                <td>4.9</td>
                <td>1.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Marisol Castañeda Pérez</td>
                <td>3.9</td>
                <td>2.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
            </table>
           </div>
         </div>

         <div id="Profesores" class="tabcontent2 " style="display: none;">
           <h3 class="centrar">Profesores</h3>
           <div class="row">
             <table>
               <tr>
                 <th rowspan="2">Alumno</th>
                 <th colspan="2">Resultados de Cuestionario de Afectividad Positiva y Negativa</th>
                 <th colspan="2">Resultados del Análisis de Expresiones Faciales</th>
               </tr>
               <tr>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
               </tr>
              <tr>
                <td>Luis Enrique Rangel Delgado</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Alonso Navarro Rubén</td>
                <td>2.3</td>
                <td>4.1</td>
                <td>3.1</td>
                <td>4</td>
              </tr>
              <tr>
                <td>Víctor Hugo Alejo Guerrero</td>
                <td>4.5</td>
                <td>4</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alberto Pérez Arbea</td>
                <td>2.9</td>
                <td>3.5</td>
                <td>4.8</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Socorro Arias Rodríguez</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Javier Leonardo Viñas Ovalle</td>
                <td>4.3</td>
                <td>4.6</td>
                <td>2.4</td>
                <td>4.4</td>
              </tr>
              <tr>
                <td>Matilde Basaldúa Ramírez</td>
                <td>3.6</td>
                <td>4.1</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alfredo Flores Barrera</td>
                <td>3.8</td>
                <td>3.2</td>
                <td>4</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Miguel Ángel Vázquez Torres</td>
                <td>4.9</td>
                <td>1.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Marisol Castañeda Pérez</td>
                <td>3.9</td>
                <td>2.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
            </table>
           </div>
         </div>

         <div id="Amigos" class="tabcontent2 " style="display: none;">
           <h3 class="centrar">Amigos</h3>
           <div class="row">
             <table>
               <tr>
                 <th rowspan="2">Alumno</th>
                 <th colspan="2">Resultados de Cuestionario de Afectividad Positiva y Negativa</th>
                 <th colspan="2">Resultados del Análisis de Expresiones Faciales</th>
               </tr>
               <tr>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
               </tr>
              <tr>
                <td>Luis Enrique Rangel Delgado</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Alonso Navarro Rubén</td>
                <td>2.3</td>
                <td>4.1</td>
                <td>3.1</td>
                <td>4</td>
              </tr>
              <tr>
                <td>Víctor Hugo Alejo Guerrero</td>
                <td>4.5</td>
                <td>4</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alberto Pérez Arbea</td>
                <td>2.9</td>
                <td>3.5</td>
                <td>4.8</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Socorro Arias Rodríguez</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Javier Leonardo Viñas Ovalle</td>
                <td>4.3</td>
                <td>4.6</td>
                <td>2.4</td>
                <td>4.4</td>
              </tr>
              <tr>
                <td>Matilde Basaldúa Ramírez</td>
                <td>3.6</td>
                <td>4.1</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alfredo Flores Barrera</td>
                <td>3.8</td>
                <td>3.2</td>
                <td>4</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Miguel Ángel Vázquez Torres</td>
                <td>4.9</td>
                <td>1.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Marisol Castañeda Pérez</td>
                <td>3.9</td>
                <td>2.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
            </table>
           </div>
         </div>

         <div id="Familia" class="tabcontent2 " style="display: none;">
           <h3 class="centrar">Familia</h3>
           <div class="row">
             <table>
               <tr>
                 <th rowspan="2">Alumno</th>
                 <th colspan="2">Resultados de Cuestionario de Afectividad Positiva y Negativa</th>
                 <th colspan="2">Resultados del Análisis de Expresiones Faciales</th>
               </tr>
               <tr>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
               </tr>
              <tr>
                <td>Luis Enrique Rangel Delgado</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Alonso Navarro Rubén</td>
                <td>2.3</td>
                <td>4.1</td>
                <td>3.1</td>
                <td>4</td>
              </tr>
              <tr>
                <td>Víctor Hugo Alejo Guerrero</td>
                <td>4.5</td>
                <td>4</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alberto Pérez Arbea</td>
                <td>2.9</td>
                <td>3.5</td>
                <td>4.8</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Socorro Arias Rodríguez</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Javier Leonardo Viñas Ovalle</td>
                <td>4.3</td>
                <td>4.6</td>
                <td>2.4</td>
                <td>4.4</td>
              </tr>
              <tr>
                <td>Matilde Basaldúa Ramírez</td>
                <td>3.6</td>
                <td>4.1</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alfredo Flores Barrera</td>
                <td>3.8</td>
                <td>3.2</td>
                <td>4</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Miguel Ángel Vázquez Torres</td>
                <td>4.9</td>
                <td>1.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Marisol Castañeda Pérez</td>
                <td>3.9</td>
                <td>2.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
            </table>
           </div>
         </div>

         <div id="Tarea" class="tabcontent2 " style="display: none;">
           <h3 class="centrar">Tareas</h3>
           <div class="row">
             <table>
               <tr>
                 <th rowspan="2">Alumno</th>
                 <th colspan="2">Resultados de Cuestionario de Afectividad Positiva y Negativa</th>
                 <th colspan="2">Resultados del Análisis de Expresiones Faciales</th>
               </tr>
               <tr>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
                 <th>Promedio de afectividad positiva</th>
                 <th>Promedio de afectividad negativa</th>
               </tr>
              <tr>
                <td>Luis Enrique Rangel Delgado</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Alonso Navarro Rubén</td>
                <td>2.3</td>
                <td>4.1</td>
                <td>3.1</td>
                <td>4</td>
              </tr>
              <tr>
                <td>Víctor Hugo Alejo Guerrero</td>
                <td>4.5</td>
                <td>4</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alberto Pérez Arbea</td>
                <td>2.9</td>
                <td>3.5</td>
                <td>4.8</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Socorro Arias Rodríguez</td>
                <td>4.2</td>
                <td>2.3</td>
                <td>3.8</td>
                <td>3.5</td>
              </tr>
              <tr>
                <td>Javier Leonardo Viñas Ovalle</td>
                <td>4.3</td>
                <td>4.6</td>
                <td>2.4</td>
                <td>4.4</td>
              </tr>
              <tr>
                <td>Matilde Basaldúa Ramírez</td>
                <td>3.6</td>
                <td>4.1</td>
                <td>4.2</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Alfredo Flores Barrera</td>
                <td>3.8</td>
                <td>3.2</td>
                <td>4</td>
                <td>3.6</td>
              </tr>
              <tr>
                <td>Miguel Ángel Vázquez Torres</td>
                <td>4.9</td>
                <td>1.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
              <tr>
                <td>Marisol Castañeda Pérez</td>
                <td>3.9</td>
                <td>2.5</td>
                <td>4.5</td>
                <td>3.4</td>
              </tr>
            </table>
           </div>
         </div>

         <!--FIN contextos-->
       </div>

       <!--
       <div class="card col-md-3 col-md-offset-1">
         <h3 class="centrar">Actividades extracurriculares</h3>
       </div>

       <div class="card col-md-3 col-md-offset-1">
         <h3 class="centrar">Compañeros</h3>
       </div>

       <div class="card col-md-3 col-md-offset-1">
         <h3 class="centrar">Profesores</h3>
       </div>

       <div class="card col-md-3 col-md-offset-1">
         <h3 class="centrar">Amigos</h3>
       </div>

       <div class="card col-md-3 col-md-offset-1">
         <h3 class="centrar">Familia</h3>
       </div>

       <div class="card col-md-3 col-md-offset-1">
         <h3 class="centrar">Tareas</h3>
       </div>
     </div>
      -->

   </div>
 </div>

 <?php include('footer.php'); ?>
 <link rel="stylesheet" type="text/css" href="assets/css/views/alumnos_clase.css">
 <script src="Chart.min.js"></script>
 <script type="text/javascript" src="assets/js/views/alumnos_clase.js"></script>
