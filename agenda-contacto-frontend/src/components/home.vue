<script setup>
import { ref } from 'vue';
import FormVue from './FormVue.vue';

const formularioActivo = ref(false);
const mostrarFormulario = () => {
    formularioActivo.value = !formularioActivo.value;
};

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
      <button type="submit" @click="mostrarFormulario"
      class="bg-sky-600 text-white p-2 border-2 
      border-white px-6 rounded-xl hover:scale-110 transition-transform">
         Agregar +
      </button>
   </div>
   <main class="h-screen bg-gradient-to-br from-black via-sky-950 to-gray-800 flex flex-wrap justify-around">
      <cards />
      <FormVue v-if="formularioActivo" @cerrar="formularioActivo = false" />
   </main>
</template>
