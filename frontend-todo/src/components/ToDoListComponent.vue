<template>
  <div>
    <h1 class="display-4 text-center">Tareas</h1>
    <hr>
    <div class="row">
      <div class="col-lg-8 offset-lg-2">
        <div class="card mt-4">
          <div class="card-body">
            <div class="input-group">
              <input type="text" v-model="tarea" class="form-control form-control-lg" placeholder="Agregar">
              <div class="input-group-append">
                <button v-on:click="agregarTarea()" class="btn btn-success btn-lg">Agregar</button>
              </div>
            </div>
            <br>
            <pendientes-component
              v-bind:listaTareas="listaTareas"
              v-on:marcarTareaResuelta="marcarTareaResuelta"
              v-on:eliminarTarea="eliminarTarea"></pendientes-component>
          </div>
           <div class="card-body">
             <completadas-component
              v-bind:listaTareas="listaTareas"
              v-on:marcarTareaPorHacer="marcarTareaPorHacer"
              v-on:eliminarTarea="eliminarTarea"></completadas-component>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
//import axios from  "axios";
import Tarea from '../models/Tarea.js';
import PendientesComponent from './PendientesComponent'
import CompletadasComponent from './CompletadasComponent'

  export default {
    name: 'ToDoListComponent',

    components: {
    CompletadasComponent,
    PendientesComponent
    },

    data(){
      return {
        tarea: '',
        listaTareas:[]
      }
    },
    
    methods: {
      agregarTarea(){
        const tarea = new Tarea(this.tarea, false);
        this.listaTareas.push(tarea);
        this.tarea = '';
      },
       marcarTareaResuelta(id){
        this.listaTareas[id].estado = true;
      },
       marcarTareaPorHacer(id){
        this.listaTareas[id].estado = false;
      },
       eliminarTarea(id){
        this.listaTareas.splice(id,1);
      },
      }
    //    obtenerTareas(){
    //     axios.get("http://localhost:5288/api/Tarea").then(respuesta => {
    //       console.log(respuesta);
    //     })  
    //   }
    // }, 
    // created: function(){
    //   this.obtenerTareas();
    // }
  }
</script>

<style scoped>
.cursor{
  cursor: pointer;
}
</style>