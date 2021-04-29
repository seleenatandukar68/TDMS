<template>
  <div class="container">
    this is home
 <div v-for="item in teles" v-bind:key="item.id">
  {{item.name}}
</div>
    
  </div>
</template>

<script>
// @ is an alias to /src
import {getTeleDirectory} from "@/core/teleDirectory.api.js"

export default {
  name: "Home",
  data(){
    return{
      teles: []
    }
  },
  mounted(){
    this.fetchUsers();
  },
  methods:{
   async fetchUsers () {

      const response = await getTeleDirectory();
     
      this.teles = response.data;
    }
  }

};
</script>
