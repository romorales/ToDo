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
            <h1 v-show="listaTareas.length !== 0" class="display-6 text-center" >Por hacer</h1>
            <ul class="list-group">
              <li v-for="(tarea, index) of listaTareas" :key="index" class="list-group-item d-flex justify-content-between">
                <span class="cursor" v-on:click="marcarTareaResuelta(index)">
                  <i class="fa-regular fa-circle"></i>
                </span>
                {{ tarea.nombre }}
               <span class="text-danger cursor"  v-on:click="eliminarTarea(index)">
                <i class="fas fa-trash"></i>
                </span>
              </li>
              
            </ul>

          </div>

           <div class="card-body">
             
            <br>
           <h1 v-show="listaTareasResueltas.length !== 0" class="display-6 text-center">Resueltas</h1>
             <ul class="list-group">
              <li v-for="(tarea, index) of listaTareasResueltas" :key="index" class="list-group-item d-flex justify-content-between">
                <span class="cursor" v-on:click="marcarTareaPorHacer(index)" aria-label="Marcar">
                  <i class="fas fa-check-circle"></i>
                </span>
                {{ tarea.nombre }}
                <span class="text-danger cursor"  v-on:click="eliminarTareaResuelta(index)">
                <i class="fas fa-trash"></i>
                </span>
              </li>
            </ul>

          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from  "axios";
  export default {
    name: 'TareaApp',
    data(){
      return {
        tarea: '',
        listaTareas: [],
        listaTareasResueltas: [],
      }
    },
    methods: {
      agregarTarea(){
        const tarea = {
          nombre: this.tarea
        }

        this.listaTareas.push(tarea);
        this.tarea = '';
      },
       marcarTareaResuelta(index){
        this.listaTareasResueltas.push(this.listaTareas[index]);
        this.eliminarTarea(index);
      },
       marcarTareaPorHacer(index){
        this.listaTareas.push(this.listaTareasResueltas[index]);
         this.eliminarTareaResuelta(index);
      },
       eliminarTarea(index){
        this.listaTareas.splice(index,1);
      },
       eliminarTareaResuelta(index){
        this.listaTareasResueltas.splice(index,1);
      },
       obtenerTareas(){
        axios.get("http://localhost:5288/api/Tarea").then(respuesta => {
          console.log(respuesta);
        })  
      }
    }, 
    created: function(){
      this.obtenerTareas();
    }
  }
</script>

<style scoped>
.cursor{
  cursor: pointer;
}
</style>