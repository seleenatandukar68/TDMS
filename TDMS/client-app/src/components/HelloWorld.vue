<template>
  <ul id="example-1">
  <li v-for="item in teleDirectories" :key="item.id">
    {{ item.name }}
  </li>
</ul>
</template>
<script>
import axios from 'axios'

export default ({
name: 'HelloWorld',
data(){return {
  teleDirectories: []
}},
mounted(){
  this.fetchUsers();
},
methods:{
   fetchUsers: function () {
      const baseURI = "http://localhost:50110/api/TeleDirectory"
      axios.get(baseURI)
      .then((result) => {
        this.teleDirectories = result.data
      })
    }
}
})
</script>
