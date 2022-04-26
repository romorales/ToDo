import { createApp } from 'vue'
import App from './App.vue'
import store from './models/Store';

//createApp(App).mount('#app')

// import { createStore } from 'vuex'

// // Create a new store instance.
// const store = createStore({
//   state () {
//     return {
//       listaTareas: []
//     }
//   }, 
//   mutations: {
//     agregarTarea (state, tarea) {
//       state.listaTareas.push(tarea);
//     },
//     cambiarEstadoTarea (state, id, estado) {
//         state.listaTareas[id].estado = estado;
//       },
//     eliminarTarea (state, id) {
//         state.listaTareas.splite(id, 1);
//       },
//   }
// })

const app = createApp(App)
app.use(store);
app.mount('#app')

// Install the store instance as a plugin
