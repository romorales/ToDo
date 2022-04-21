<template>
  <div>
    <div class="card-body">
           <h1 v-show="Array.isArray(listaTareasCompletadas) && listaTareasCompletadas.length !== 0" class="display-6 text-center">Resueltas</h1>
             <ul class="list-group">
              <li v-for="(tarea, index) of listaTareasCompletadas" :key="index" class="list-group-item d-flex justify-content-between">
                <span class="cursor" v-on:click="marcarTareaPorHacer(tarea.id)" aria-label="Marcar">
                  <i class="fas fa-check-circle"></i>
                </span>
                {{ tarea.nombre }}
                <span class="text-danger cursor"  v-on:click="eliminarTarea(tarea.id)">
                <i class="fas fa-trash"></i>
                </span>
              </li>
            </ul>
          </div>
        </div>
</template>

<script>
  export default {
    name: 'CompletadasComponent',
    props:['listaTareas'],
    
    data(){
      return {
      }
    },

    computed: {  
      listaTareasCompletadas(){
        let lista = [];
        for(let i = 0; i < this.listaTareas.length; i++)
        {
          let tarea = {
            id: i,
            nombre: this.listaTareas[i].nombre
          }

          if (this.listaTareas[i].estado == true)
          {
            lista.push(tarea); 
          }
        } 
        return lista;
      }
    },

    methods: {
      marcarTareaPorHacer(id){
        this.$emit('marcarTareaPorHacer', [id]);
      },
      eliminarTarea(id){
        this.$emit('eliminarTarea', [id]);
      },
    }, 
  }
</script>

<style scoped>
.cursor{
  cursor: pointer;
}
</style>