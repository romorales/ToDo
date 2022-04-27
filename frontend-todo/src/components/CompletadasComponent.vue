<template>
  <div>
    <div class="card-body">
      <div v-if="Array.isArray(listaTareasCompletadas) && listaTareasCompletadas.length > 0" class="middle-side">
           <h1 class="display-6 text-center">Resueltas</h1>
             <ul class="list-group">
              <li v-for="tarea in listaTareasCompletadas" :key="tarea.id" class="list-group-item d-flex justify-content-between">
                <span class="cursor" v-on:click="cambiarEstadoTarea(tarea.id, tarea)" aria-label="Marcar">
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
    </div>
</template>

<script>
  export default {
    name: 'CompletadasComponent',
    props: ['listaTareas'],
    
    computed: {  
      listaTareasCompletadas(){
       return this.listaTareas;
      }
    },

    methods: {
      cambiarEstadoTarea(id, tarea){
        this.$emit('cambiarEstadoTarea', [id], tarea);
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