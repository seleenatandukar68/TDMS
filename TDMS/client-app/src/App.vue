<template>
  <div id="app">
    <div id="nav"> 
      <TopMenu/>


    </div>
    <router-view />
   
  </div>
</template>
<script>
import TopMenu from "@/components/Menu/TopMenu.vue";


export default {
  name :'app',
  components:{
    TopMenu,
   
  },
 
  
}
</script>
