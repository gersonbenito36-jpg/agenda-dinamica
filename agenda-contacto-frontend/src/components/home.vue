<script setup>
import { ref, onMounted } from 'vue';
import FormVue from './FormVue.vue';
import {traerContactos} from '../services/services.js'
import { eliminarContactos } from '../services/services.js';

const formularioActivo = ref(false);
const mostrarFormulario = () => {
    formularioActivo.value = !formularioActivo.value;
};
const contactos = ref([])
const cargarContactos = async () =>{
   const respuesta = await traerContactos()
   contactos.value = respuesta.data
}

const deleteContacto = async(id) =>{
   await eliminarContactos(id)
   await cargarContactos
}

onMounted(() =>{
   cargarContactos()
} )


</script>

<template>
   <header class="bg-sky-800 p-8">
      <h1 class="text-white text-3xl
      font-bold text-center">Bienvenido a tu Agenda de contactos</h1>
   </header>
   <div class="w-full bg-green-400 p-6 flex flex-row justify-around flex gap-8 px-10">
      <input type="text"
      placeholder="type a name to search in this web"
      name="search"
      class="w-1/2  rounded-lg border-4 border-red-500">
      <button type="button" @click="mostrarFormulario"
      class="bg-sky-600 text-white p-2 border-2 
      border-white px-6 rounded-xl hover:scale-110 transition-transform">
         Agregar +
      </button>
   </div>
   <main class="h-screen bg-gradient-to-br from-black via-sky-950 to-gray-800 ">
      <div class="p-8 grid grid-cols-3 gap-8 w-8xl">
         <div v-for="contacto in contactos"
         :key="contacto.id"
         class="bg-white rounded-xl p-2 flex flex-col items-center hover:scale-105 cursor-pointer">
         <div class="w-16 h-16 rounded-full bg-blue-200 flex items-center justify-center font-bold text-blue-600 hover:scale-110 transition-transform">
           {{ contacto.nombre.charAt(0).toUpperCase() }} 
         </div>
         <div class="">
            <p class="text-gray-800 font-bold text-xl">Nombre: {{ contacto.nombre }}</p>
            <p class="text-gray-800 font-bold text-xl">Telefono: {{contacto.telefono}}</p>
            <p class="text-gray-800 font-bold text-xl">Email: {{ contacto.correo }}</p>
         </div>
         <div class="flex items-center justify-between p-2 m-2">
            <button  class="text-white text-sm font-bold bg-blue-400 p-4 rounded-lg mr-2 cursor-pointer hover:scale-110 transition-transform hover:bg-blue-600">Editar</button>
            <button @click="deleteContacto(contacto.id)" class="ml-2 bg-red-500 text-white p-4 rounded-lg text-sm font-bold cursor-pointer hover:scale-110 transition-transform hover:bg-red-700">Eliminar</button>
         </div>

         </div>
      </div>
      <FormVue v-if="formularioActivo" @contactoCreado ="cargarContactos" @cerrar="formularioActivo = false" />
   </main>
</template>
