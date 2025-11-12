<h1 align="center">🎮 Ladrón Elegante — Proyecto Test (Versión 2022)</h1>

<p align="center">
  <i>Prototipo técnico enfocado en el desarrollo y testeo de una IA modular de sigilo</i>
</p>

---

<h3 align="left">🧠 Descripción General</h3>
<p>
Este proyecto representó la primera versión experimental de <b>Ladrón Elegante</b>, centrado en el desarrollo de un sistema de IA completamente modular.  
El objetivo fue crear una base sólida de comportamientos inteligentes para enemigos, probando la comunicación entre diferentes subsistemas como visión, audición y estado general.
</p>

---

<h3 align="left">⚙️ Características Principales</h3>
<ul>
  <li>Diseño de IA <b>totalmente modular</b> utilizando <b>interfaces</b> para lograr acoplamiento y desacoplamiento dinámico de comportamientos.</li>
  <li>Clase principal <b>BaseIA.cs</b> encargada de administrar el estado actual del enemigo y coordinar sus transiciones.</li>
  <li>Sistemas sensoriales independientes:
    <ul>
      <li><b>Eyes.cs:</b> gestiona el cono de visión y la detección visual del jugador.</li>
      <li><b>Ears.cs:</b> detecta fuentes de sonido cercanas, como pasos o ruidos provocados.</li>
    </ul>
  </li>
  <li>Estados de comportamiento implementados:
    <ul>
      <li><b>Patrulla (Patrol)</b> — recorrido predefinido o aleatorio del entorno.</li>
      <li><b>Sospecha visual</b> — el enemigo cree haber visto algo.</li>
      <li><b>Sospecha auditiva</b> — reacciona ante ruidos cercanos.</li>
      <li><b>Detectado</b> — confirma la presencia del jugador.</li>
      <li><b>Alerta</b> — entra en búsqueda activa.</li>
      <li><b>Estado de llamada</b> — Llama a la Policia.</li>
    </ul>
  </li>
  <li>Lógica de cámara <b>programada desde cero</b>, sin uso de Cinemachine.</li>
  <li>Enfoque en <b>testeo y análisis de comportamientos IA</b> como base para futuros proyectos.</li>
</ul>

---

<h3 align="left">🎯 Objetivos del Proyecto</h3>
<ul>
  <li>Experimentar con arquitecturas de IA modulares y reutilizables.</li>
  <li>Probar la comunicación entre componentes sensoriales y el sistema de decisión central.</li>
  <li>Identificar limitaciones y posibles mejoras para un desarrollo más limpio en futuras versiones.</li>
</ul>

---

<h3 align="left">💡 Resultado</h3>
<p>
El proyecto permitió validar la <b>estructura modular de IA</b> y sentó las bases para una nueva versión más limpia y escalable del juego.  
El sistema de interfaces y la separación por componentes sensoriales demostraron ser efectivos, facilitando la transición hacia el nuevo desarrollo con Unity 6 y HDRP.
</p>

---

<h3 align="left">🛠 Tecnologías Utilizadas</h3>
<ul>
  <li><b>Motor:</b> Unity 2022</li>
  <li><b>Lenguaje:</b> C#</li>
  <li><b>Arquitectura:</b> IA modular, uso de interfaces, separación de componentes sensoriales</li>
  <li><b>Componentes Clave:</b> BaseIA.cs, Eyes.cs, Ears.cs</li>
</ul>

---

<div align="center"> 
  <table cellspacing="0" cellpadding="0"> 
    <tr> <td valign="middle"> 
      <img src="https://raw.githubusercontent.com/MiltonCastro93/hello-world/main/youtubeIcon.png" alt="YouTube Icon" width="100" /> 
    </td> 
      <td valign="middle" style="padding-left: 20px;"> 
        <table cellspacing="0" cellpadding="5"> 
          <tr> <td align="center"> :zap: Proyecto en desarrollo (Patreon) </td> 
          <tr> <td align="center"> <a href="https://www.youtube.com/playlist?list=PL_82nVaL4agwx_hbE09cWLHEPAsUg4tA4"><b>El Ladrón Elegante</b></a> </td> 
          </tr> 
        </table> 
      </td> 
    </tr> 
  </table> 
</div>

---

<h3 align="left">🔗 Repositorio </h3>
<p align="center">
  <a href="https://github.com/MiltonCastro93/Estructura-IA_Status" target="_blank">
    👉 Ver repositorio del proyecto Original.
  </a>
</p>

<p align="center">
  <img src="https://visitor-badge.laobi.icu/badge?page_id=MiltonCastro93.LadronElegante_Viejo" alt="Visitas"/>
</p>
