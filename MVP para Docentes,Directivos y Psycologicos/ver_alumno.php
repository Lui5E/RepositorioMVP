<?php
  include('header.php');
  if(isset($_GET['ID']) && isset($_SESSION['trabajador']))
  {
    $id = $_GET['ID'];
  }
  else
  {
    header('Location: index_docente.php');
  }
  $interesado_1 = 0;
  $aflijido_2 = 0;
  $excitado_3 = 0;
  $disgustado_4 = 0;
  $fuerte_5 = 0;
  $culpable_6 = 0;
  $asustado_7 = 0;
  $hostil_8 = 0;
  $entusiasmado_9 = 0;
  $orgulloso_10 = 0;
  $irritable_11 = 0;
  $alerta_12 = 0;
  $inspirado_13 = 0;
  $avergonzado_14 = 0;
  $nervioso_15 = 0;
  $decidido_16 = 0;
  $atento_17 = 0;
  $intranquilo_18 = 0;
  $activo_19 = 0;
  $temeroso_20 = 0;
  //Conexión a BD
  try{
    $conn = new mysqli('localhost', 'root', '', 'bilbo');
		if(!$conn->connect_error)
    {
      $sql = "
          select
            *
          from
            respuestas_alumnos
          where
            tipo_respuesta = 2
					  and   alumno_id = '".$id."'";
			$sql_respuesta = $conn->query($sql);
      if($sql_respuesta)
      {
        while($row = $sql_respuesta -> fetch_assoc())
        {

          $interesado_1 += $row['respuesta_PANAS'][0];
          $aflijido_2 += $row['respuesta_PANAS'][2];
          $excitado_3 += $row['respuesta_PANAS'][4];
          $disgustado_4 += $row['respuesta_PANAS'][6];
          $fuerte_5 += $row['respuesta_PANAS'][8];
          $culpable_6 += $row['respuesta_PANAS'][10];
          $asustado_7 += $row['respuesta_PANAS'][12];
          $hostil_8 += $row['respuesta_PANAS'][14];
          $entusiasmado_9 += $row['respuesta_PANAS'][16];
          $orgulloso_10 += $row['respuesta_PANAS'][18];
          $irritable_11 += $row['respuesta_PANAS'][20];
          $alerta_12 += $row['respuesta_PANAS'][22];
          $inspirado_13 += $row['respuesta_PANAS'][24];
          $avergonzado_14 += $row['respuesta_PANAS'][26];
          $nervioso_15 += $row['respuesta_PANAS'][28];
          $decidido_16 += $row['respuesta_PANAS'][30];
          $atento_17 += $row['respuesta_PANAS'][32];
          $intranquilo_18 += $row['respuesta_PANAS'][34];
          $activo_19 += $row['respuesta_PANAS'][36];
          $temeroso_20 += $row['respuesta_PANAS'][38];

        }
        $porcetaje_interesado_1 = $interesado_1/$sql_respuesta->num_rows;
        $porcentaje_aflijido_2 = $aflijido_2/$sql_respuesta->num_rows;
        $porcentaje_excitado_3 = $excitado_3/$sql_respuesta->num_rows;
        $porcentaje_disgustado_4 = $disgustado_4/$sql_respuesta->num_rows;
        $porcentaje_fuerte_5 = $fuerte_5/$sql_respuesta->num_rows;
        $porcentaje_culpable_6 = $culpable_6/$sql_respuesta->num_rows;
        $porcentaje_asustado_7 = $asustado_7/$sql_respuesta->num_rows;
        $porcentaje_hostil_8 = $hostil_8/$sql_respuesta->num_rows;
        $porcentaje_entusiasmado_9 = $entusiasmado_9/$sql_respuesta->num_rows;
        $porcentaje_orgulloso_10 = $orgulloso_10/$sql_respuesta->num_rows;
        $porcentaje_irritable_11 = $irritable_11/$sql_respuesta->num_rows;
        $porcentaje_alerta_12 = $alerta_12/$sql_respuesta->num_rows;
        $porcentaje_inspirado_13 = $inspirado_13/$sql_respuesta->num_rows;
        $porcentaje_avergonzado_14 = $avergonzado_14/$sql_respuesta->num_rows;
        $porcentaje_nervioso_15 = $nervioso_15/$sql_respuesta->num_rows;
        $porcentaje_decidido_16 = $decidido_16/$sql_respuesta->num_rows;
        $porcentaje_atento_17 = $atento_17/$sql_respuesta->num_rows;
        $porcentaje_intranquilo_18 = $intranquilo_18/$sql_respuesta->num_rows;
        $porcentaje_activo_19 = $activo_19/$sql_respuesta->num_rows;
        $porcentaje_temeroso_20 = $temeroso_20/$sql_respuesta->num_rows;
        //
        //Todas las emociones(promediadas cada una) positivas del panas
        $positivas = [$interesado_1,$excitado_3,$fuerte_5,$entusiasmado_9,$orgulloso_10,
        $alerta_12,$inspirado_13,$decidido_16,$atento_17,$activo_19];
        //Todas las emociones(promediadas cada una) negativas del panas
        $negativas = [$aflijido_2,$disgustado_4,$culpable_6,$asustado_7,$hostil_8,
        $irritable_11,$avergonzado_14,$nervioso_15,$intranquilo_18,$temeroso_20];
        //Porcentaje de emociones positivas sentidas
        $porcentaje_positivas = 0;
        foreach ($positivas as $valor)
        {
          $porcentaje_positivas += $valor;
        }
        //echo "P".$porcentaje_positivas."---";
        $porcentaje_positivas /=5;
        //Porcentaje de emociones negativas sentidas
        $porcentaje_negativas = 0;
        foreach ($negativas as $valor)
        {
          $porcentaje_negativas += $valor;
        }
        //echo "N".$porcentaje_negativas;
        $porcentaje_negativas /=5;
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

 <div class="container col-container">
   <!--Prueba tabulación vertical-->
   <div id="opciones" class="tab col">
     <button class="tablinks" onclick="abrirContexto(event, 'Actividades')">Actividades</button>
     <button class="tablinks" onclick="abrirContexto(event, 'Compañeros')">Compañeros</button>
     <button class="tablinks" onclick="abrirContexto(event, 'Profesores')">Profesores</button>
     <button class="tablinks" onclick="abrirContexto(event, 'Amigos')">Amigos</button>
     <button class="tablinks" onclick="abrirContexto(event, 'Familia')">Familia</button>
     <button class="tablinks" onclick="abrirContexto(event, 'Tarea')">Tarea</button>
   </div>
   <div id="Actividades" class="tabcontent col" style="display: block;">
     <h3 class="centrar">Actividades extracurriculares</h3>
     <div class="resultados">
       <div class="row">
         <h4 class="centrar">Resultados de Cuestionario de Afectividad Positiva y Negativa</h4>
         <div class="positivo">
           <p>Promedio de afectividad positiva (valores de 1 - 5): <b>4.3</b></p>
         </div>
         <div class="negativo">
           <p>Promedio de afectividad negativa (valores de 1 - 5): <b>2.1</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="ACTpositivePANASChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="ACTnegativePANASChart" width="300" height="300"></canvas>
         </div>
       </div>
       <div class="row">
         <h4 class="centrar">Resultados del Análisis de Expresiones Faciales</h4>
         <div class="positivo">
           <p class="centrar">Promedio de afectividad positiva (valores de 0 - 5): <b>4.3</b></p>
         </div>
         <div class="negativo">
           <p class="centrar">Promedio de afectividad negativa (valores de 0 - 5): <b>2.1</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="ACTpositiveAPIChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="ACTnegativeAPIChart" width="300" height="300"></canvas>
         </div>
       </div>
     </div>
     <?php if($_SESSION['bilbo']['tipo_usuario'] == 3): ?>
     <!--     Preguntas Contexto-->
     <h4 class="centrar">Preguntas y respuestas "Preguntas de Contexto"</h4>
     <div class="tabCon">
       <button class="tablinksCon" onclick="Con(event, 'Uno')">1</button>
       <button class="tablinksCon" onclick="Con(event, 'Dos')">2</button>
       <button class="tablinksCon" onclick="Con(event, 'Tres')">3</button>
     </div>

     <!-- Tab content -->
     <div id="Uno" class="tabcontentCon" style="display: block;">
       <h3>Indica como te sentiste hoy al levantarte en la mañana</h3>
       <textarea name="respuesta" readonly>Bien, me levante y recorde lo bueno que fue mi día anterior y pense que este día sería igual o mejor</textarea>
     </div>

     <div id="Dos" class="tabcontentCon" style="display: none;">
       <h3>¿Quisieras hacer algo en especial el día de hoy?</h3>
       <textarea name="respuesta" readonly>No, lo normal e ir a comer con mis padres</textarea>
     </div>

     <div id="Tres" class="tabcontentCon" style="display: none;">
       <h3>Relata el mejor día que hayas tenido en el mes anterior</h3>
       <textarea name="respuesta" readonly>
Fue un viernes, ese día en la escuela saque la mejor nota del salón en la clase de química, eso me hizo sentir bien ya que me había pasado todo el día anterior estudiando, por la tarde mis amigos y yo estuvimos jugando fútbol en las canchas de la unidad cerca de mi casa, ganamos varios partidos y cuando no los ganábamos nos la pasábamos platicando con un viejo entrenador de un equipo de fútbol reconocido, el pareció fascinado por como jugábamos y nos invito a formar un equipo de liga, me divertí mucho
       </textarea>
     </div>
     <!--     Fin Preguntas Contexto-->
   <?php endif; ?>
   </div>

   <div id="Compañeros" class="tabcontent col"  style="display: none;">
     <h3 class="centrar">Compañeros</h3>
     <div class="resultados">
       <div class="row">
         <h4 class="centrar">Resultados de Cuestionario de Afectividad Positiva y Negativa</h4>
         <div class="positivo">
           <p>Promedio de afectividad positiva (valores de 1 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p>Promedio de afectividad negativa (valores de 1 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="COMPANEROSpositivePANASChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="COMPANEROSnegativePANASChart" width="300" height="300"></canvas>
         </div>
       </div>
       <div class="row">
         <h4 class="centrar">Resultados del Análisis de Expresiones Faciales</h4>
         <div class="positivo">
           <p class="centrar">Promedio de afectividad positiva (valores de 0 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p class="centrar">Promedio de afectividad negativa (valores de 0 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="COMPANEROSpositiveAPIChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="COMPANEROSnegativeAPIChart" width="300" height="300"></canvas>
         </div>
       </div>
     </div>
     <?php if($_SESSION['bilbo']['tipo_usuario'] == 3): ?>
     <!--     Preguntas Contexto-->
     <h4 class="centrar">Preguntas y respuestas "Preguntas de Contexto"</h4>
     <div class="tabCon">
       <button class="tablinksCon" onclick="Con(event, 'Uno')">1</button>
       <button class="tablinksCon" onclick="Con(event, 'Dos')">2</button>
       <button class="tablinksCon" onclick="Con(event, 'Tres')">3</button>
     </div>

     <!-- Tab content -->
     <div id="Uno" class="tabcontentCon" style="display: block;">
       <h3>Indica como te sentiste hoy al levantarte en la mañana</h3>
       <textarea name="respuesta" readonly>Bien, me levante y recorde lo bueno que fue mi día anterior y pense que este día sería igual o mejor</textarea>
     </div>

     <div id="Dos" class="tabcontentCon" style="display: none;">
       <h3>¿Quisieras hacer algo en especial el día de hoy?</h3>
       <textarea name="respuesta" readonly>No, lo normal e ir a comer con mis padres</textarea>
     </div>

     <div id="Tres" class="tabcontentCon" style="display: none;">
       <h3>Relata el mejor día que hayas tenido en el mes anterior</h3>
       <textarea name="respuesta" readonly>
Fue un viernes, ese día en la escuela saque la mejor nota del salón en la clase de química, eso me hizo sentir bien ya que me había pasado todo el día anterior estudiando, por la tarde mis amigos y yo estuvimos jugando fútbol en las canchas de la unidad cerca de mi casa, ganamos varios partidos y cuando no los ganábamos nos la pasábamos platicando con un viejo entrenador de un equipo de fútbol reconocido, el pareció fascinado por como jugábamos y nos invito a formar un equipo de liga, me divertí mucho
       </textarea>
     </div>
     <!--     Fin Preguntas Contexto-->
   <?php endif; ?>
   </div>

   <div id="Profesores" class="tabcontent col" style="display: none;">
     <h3 class="centrar">Profesores</h3>
     <div class="resultados">
       <div class="row">
         <h4 class="centrar">Resultados de Cuestionario de Afectividad Positiva y Negativa</h4>
         <div class="positivo">
           <p>Promedio de afectividad positiva (valores de 1 - 5):e <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p>Promedio de afectividad negativa (valores de 1 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="PROFESORESpositivePANASChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="PROFESORESnegativePANASChart" width="300" height="300"></canvas>
         </div>
       </div>
       <div class="row">
         <h4 class="centrar">Resultados del Análisis de Expresiones Faciales</h4>
         <div class="positivo">
           <p class="centrar">Promedio de afectividad positiva (valores de 0 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p class="centrar">Promedio de afectividad negativa (valores de 0 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="PROFESORESpositiveAPIChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="PROFESORESnegativeAPIChart" width="300" height="300"></canvas>
         </div>
       </div>
     </div>

     <?php if($_SESSION['bilbo']['tipo_usuario'] == 3): ?>
     <!--     Preguntas Contexto-->
     <h4 class="centrar">Preguntas y respuestas "Preguntas de Contexto"</h4>
     <div class="tabCon">
       <button class="tablinksCon" onclick="Con(event, 'Uno')">1</button>
       <button class="tablinksCon" onclick="Con(event, 'Dos')">2</button>
       <button class="tablinksCon" onclick="Con(event, 'Tres')">3</button>
     </div>

     <!-- Tab content -->
     <div id="Uno" class="tabcontentCon" style="display: block;">
       <h3>Indica como te sentiste hoy al levantarte en la mañana</h3>
       <textarea name="respuesta" readonly>Bien, me levante y recorde lo bueno que fue mi día anterior y pense que este día sería igual o mejor</textarea>
     </div>

     <div id="Dos" class="tabcontentCon" style="display: none;">
       <h3>¿Quisieras hacer algo en especial el día de hoy?</h3>
       <textarea name="respuesta" readonly>No, lo normal e ir a comer con mis padres</textarea>
     </div>

     <div id="Tres" class="tabcontentCon" style="display: none;">
       <h3>Relata el mejor día que hayas tenido en el mes anterior</h3>
       <textarea name="respuesta" readonly>
Fue un viernes, ese día en la escuela saque la mejor nota del salón en la clase de química, eso me hizo sentir bien ya que me había pasado todo el día anterior estudiando, por la tarde mis amigos y yo estuvimos jugando fútbol en las canchas de la unidad cerca de mi casa, ganamos varios partidos y cuando no los ganábamos nos la pasábamos platicando con un viejo entrenador de un equipo de fútbol reconocido, el pareció fascinado por como jugábamos y nos invito a formar un equipo de liga, me divertí mucho
       </textarea>
     </div>
     <!--     Fin Preguntas Contexto-->
   <?php endif; ?>
   </div>

   <div id="Amigos" class="tabcontent col" style="display: none;">
     <h3 class="centrar">Amigos</h3>
     <div class="resultados">
       <div class="row">
         <h4 class="centrar">Resultados de Cuestionario de Afectividad Positiva y Negativa</h4>
         <div class="positivo">
           <p>Promedio de afectividad positiva (valores de 1 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p>Promedio de afectividad negativa (valores de 1 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="AMIGOSpositivePANASChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="AMIGOSnegativePANASChart" width="300" height="300"></canvas>
         </div>
       </div>
       <div class="row">
         <h4 class="centrar">Resultados del Análisis de Expresiones Faciales</h4>
         <div class="positivo">
           <p class="centrar">Promedio de afectividad positiva (valores de 0 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p class="centrar">Promedio de afectividad negativa (valores de 0 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="AMIGOSpositiveAPIChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="AMIGOSnegativeAPIChart" width="300" height="300"></canvas>
         </div>
       </div>
     </div>
     <?php if($_SESSION['bilbo']['tipo_usuario'] == 3): ?>
     <!--     Preguntas Contexto-->
     <h4 class="centrar">Preguntas y respuestas "Preguntas de Contexto"</h4>
     <div class="tabCon">
       <button class="tablinksCon" onclick="Con(event, 'Uno')">1</button>
       <button class="tablinksCon" onclick="Con(event, 'Dos')">2</button>
       <button class="tablinksCon" onclick="Con(event, 'Tres')">3</button>
     </div>

     <!-- Tab content -->
     <div id="Uno" class="tabcontentCon" style="display: block;">
       <h3>Indica como te sentiste hoy al levantarte en la mañana</h3>
       <textarea name="respuesta" readonly>Bien, me levante y recorde lo bueno que fue mi día anterior y pense que este día sería igual o mejor</textarea>
     </div>

     <div id="Dos" class="tabcontentCon" style="display: none;">
       <h3>¿Quisieras hacer algo en especial el día de hoy?</h3>
       <textarea name="respuesta" readonly>No, lo normal e ir a comer con mis padres</textarea>
     </div>

     <div id="Tres" class="tabcontentCon" style="display: none;">
       <h3>Relata el mejor día que hayas tenido en el mes anterior</h3>
       <textarea name="respuesta" readonly>
Fue un viernes, ese día en la escuela saque la mejor nota del salón en la clase de química, eso me hizo sentir bien ya que me había pasado todo el día anterior estudiando, por la tarde mis amigos y yo estuvimos jugando fútbol en las canchas de la unidad cerca de mi casa, ganamos varios partidos y cuando no los ganábamos nos la pasábamos platicando con un viejo entrenador de un equipo de fútbol reconocido, el pareció fascinado por como jugábamos y nos invito a formar un equipo de liga, me divertí mucho
       </textarea>
     </div>
     <!--     Fin Preguntas Contexto-->
   <?php endif; ?>
   </div>

   <div id="Familia" class="tabcontent col" style="display: none;">
     <h3 class="centrar">Familia</h3>
     <div class="resultados">
       <div class="row">
         <h4 class="centrar">Resultados de Cuestionario de Afectividad Positiva y Negativa</h4>
         <div class="positivo">
           <p>Promedio de afectividad positiva (valores de 1 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p>Promedio de afectividad negativa (valores de 1 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="FAMILIApositivePANASChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="FAMILIAnegativePANASChart" width="300" height="300"></canvas>
         </div>
       </div>
       <div class="row">
         <h4 class="centrar">Resultados del Análisis de Expresiones Faciales</h4>
         <div class="positivo">
           <p class="centrar">Promedio de afectividad positiva (valores de 0 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p class="centrar">Promedio de afectividad negativa (valores de 0 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="FAMILIApositiveAPIChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="FAMILIAnegativeAPIChart" width="300" height="300"></canvas>
         </div>
       </div>
     </div>
     <?php if($_SESSION['bilbo']['tipo_usuario'] == 3): ?>
     <!--     Preguntas Contexto-->
     <h4 class="centrar">Preguntas y respuestas "Preguntas de Contexto"</h4>
     <div class="tabCon">
       <button class="tablinksCon" onclick="Con(event, 'Uno')">1</button>
       <button class="tablinksCon" onclick="Con(event, 'Dos')">2</button>
       <button class="tablinksCon" onclick="Con(event, 'Tres')">3</button>
     </div>

     <!-- Tab content -->
     <div id="Uno" class="tabcontentCon" style="display: block;">
       <h3>Indica como te sentiste hoy al levantarte en la mañana</h3>
       <textarea name="respuesta" readonly>Bien, me levante y recorde lo bueno que fue mi día anterior y pense que este día sería igual o mejor</textarea>
     </div>

     <div id="Dos" class="tabcontentCon" style="display: none;">
       <h3>¿Quisieras hacer algo en especial el día de hoy?</h3>
       <textarea name="respuesta" readonly>No, lo normal e ir a comer con mis padres</textarea>
     </div>

     <div id="Tres" class="tabcontentCon" style="display: none;">
       <h3>Relata el mejor día que hayas tenido en el mes anterior</h3>
       <textarea name="respuesta" readonly>
Fue un viernes, ese día en la escuela saque la mejor nota del salón en la clase de química, eso me hizo sentir bien ya que me había pasado todo el día anterior estudiando, por la tarde mis amigos y yo estuvimos jugando fútbol en las canchas de la unidad cerca de mi casa, ganamos varios partidos y cuando no los ganábamos nos la pasábamos platicando con un viejo entrenador de un equipo de fútbol reconocido, el pareció fascinado por como jugábamos y nos invito a formar un equipo de liga, me divertí mucho
       </textarea>
     </div>
     <!--     Fin Preguntas Contexto-->
   <?php endif; ?>
   </div>

   <div id="Tarea" class="tabcontent col" style="display: none;">
     <h3 class="centrar">Tareas</h3>
     <div class="resultados">
       <div class="row">
         <h4 class="centrar">Resultados de Cuestionario de Afectividad Positiva y Negativa</h4>
         <div class="positivo">
           <p>Promedio de afectividad positiva (valores de 1 - 5): <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p>Promedio de afectividad negativa (valores de 1 - 5): <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="TAREApositivePANASChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="TAREAnegativePANASChart" width="300" height="300"></canvas>
         </div>
       </div>
       <div class="row">
         <h4 class="centrar">Resultados del Análisis de Expresiones Faciales</h4>
         <div class="positivo">
           <p class="centrar">El promedio de emociones positivas en valores de (0 - 5) es de <b>4.1</b></p>
         </div>
         <div class="negativo">
           <p class="centrar">El promedio valor de emociones en valores de (0 - 5) es de <b>2</b></p>
         </div>
       </div>
       <div class="row">
         <div class="positivo">
           <p class="centrar">Tabla con emociones positivas</p>
           <canvas id="TAREApositiveAPIChart" width="300" height="300"></canvas>
         </div>
         <div class="negativo">
           <p class="centrar">Tabla con emociones negativas</p>
           <canvas id="TAREAnegativeAPIChart" width="300" height="300"></canvas>
         </div>
       </div>
     </div>
     <?php if($_SESSION['bilbo']['tipo_usuario'] == 3): ?>
     <!--     Preguntas Contexto-->
     <h4 class="centrar">Preguntas y respuestas "Preguntas de Contexto"</h4>
     <div class="tabCon">
       <button class="tablinksCon" onclick="Con(event, 'Uno')">1</button>
       <button class="tablinksCon" onclick="Con(event, 'Dos')">2</button>
       <button class="tablinksCon" onclick="Con(event, 'Tres')">3</button>
     </div>

     <!-- Tab content -->
     <div id="Uno" class="tabcontentCon" style="display: block;">
       <h3>Indica como te sentiste hoy al levantarte en la mañana</h3>
       <textarea name="respuesta" readonly>Bien, me levante y recorde lo bueno que fue mi día anterior y pense que este día sería igual o mejor</textarea>
     </div>

     <div id="Dos" class="tabcontentCon" style="display: none;">
       <h3>¿Quisieras hacer algo en especial el día de hoy?</h3>
       <textarea name="respuesta" readonly>No, lo normal e ir a comer con mis padres</textarea>
     </div>

     <div id="Tres" class="tabcontentCon" style="display: none;">
       <h3>Relata el mejor día que hayas tenido en el mes anterior</h3>
       <textarea name="respuesta" readonly>
Fue un viernes, ese día en la escuela saque la mejor nota del salón en la clase de química, eso me hizo sentir bien ya que me había pasado todo el día anterior estudiando, por la tarde mis amigos y yo estuvimos jugando fútbol en las canchas de la unidad cerca de mi casa, ganamos varios partidos y cuando no los ganábamos nos la pasábamos platicando con un viejo entrenador de un equipo de fútbol reconocido, el pareció fascinado por como jugábamos y nos invito a formar un equipo de liga, me divertí mucho
       </textarea>
     </div>
     <!--     Fin Preguntas Contexto-->
   <?php endif; ?>
   </div>

   <!--FIN contextos-->
 </div>

 <?php include('footer.php'); ?>
 <link rel="stylesheet" type="text/css" href="assets/css/views/ver_alumno.css">
 <script src="Chart.min.js"></script>
 <script type="text/javascript" src="assets/js/views/ver_alumno.js"></script>
