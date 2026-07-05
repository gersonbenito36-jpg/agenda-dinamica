<script setup>

</script>
<template>
   <header class="bg-sky-800 p-8 ">
      <h1 class="text-white text-3xl
      font-bold text-center">Bienvenido a tu Agenda de contactos</h1>
   </header>
   <div class="w-full bg-green-400 p-6 flex flex-row justify-around flex gap-8 px-10">
      <input type="text"
      placeholder="type a name to search in this web"
      name="search"
      class="w-1/2  rounded-lg border-4 border-red-500">
      <button type="submit"
      class="bg-sky-600 text-white p-2 border-2 
      border-white px-6 rounded-xl">
         Agregar +
      </button>
   </div>
   <main class="h-screen bg-emerald-200 flex flex-wrap justify-around">
      <div class="w-1/4 m-2 border-solid border-2 border-red-500">elemento 1</div>
      <div class="w-1/4 m-2 border-solid border-2 border-red-500">elemento 2</div>
      <div class="w-1/4 m-2 border-solid border-2 border-red-500">elemento 3</div>
      <div class="w-1/4 m-2 border-solid border-2 border-red-500">elemento 4</div>
      <div class="w-1/4 m-2 border-solid border-2 border-red-500">elemento 5</div>
      <div class="w-1/4 m-2 border-solid border-2 border-red-500">elemento 6</div>
   </main>
</template>
