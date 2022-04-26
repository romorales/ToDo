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
              v-if="listaTareas.length > 0"
              :listaTareas="tareasPendientes"
              v-on:cambiarEstadoTarea="cambiarEstadoTarea"
              v-on:eliminarTarea="eliminarTarea"></pendientes-component>
          </div>
           <div class="card-body">
             <completadas-component
              v-if="listaTareas.length > 0"
              :listaTareas="tareasCompletadas"
              v-on:cambiarEstadoTarea="cambiarEstadoTarea"
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
import store from '../models/Store';
import {mapState} from 'vuex';

  export default {
    name: 'ToDoListComponent',
    store,
    components: {
    CompletadasComponent,
    PendientesComponent
    },

    data(){
      return {
        tarea: '',
        tareasPendientes: '',
        tareasCompletadas: ''
     }
    },

    computed:{
      ...mapState([
        'listaTareas'
        ])
    },

    methods: { 
      agregarTarea(){
        const tarea = new Tarea(this.listaTareas.length, this.tarea, false);
        this.$store.dispatch('triggerFunction',
          tarea
        )
        this.tarea = '';
        this.actualizarArrays();
        },
         cambiarEstadoTarea(id){
        this.$store.commit('cambiarEstadoTarea', id);
        this.actualizarArrays();
        },
        eliminarTarea(id){
        this.$store.commit('eliminarTarea', id);
        this.actualizarArrays();
        },
        actualizarArrays(){
          this.tareasPendientes = this.$store.getters.getPendientes;
          this.tareasCompletadas = this.$store.getters.getCompletadas;
        }
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