<template>
  <div class="container container-fluid">
    <div class="card">
    <div class=" card-header">
      <div class="row p-3">
        <h4> Add Telephone Details </h4>

      </div>
      </div>
      <div class="card-body"> 
        <div class="form-group">
        <div class="row"> 
         <label class="col-md-2 col-form-label">Name</label>
          <input class="col-md-4 form-control" type="text" v-model="name"/>
        </div>
          <div class="row"> 
         <label class="col-md-2 col-form-label">Address</label>
          <input class="col-md-4 form-control" type="text" v-model="address"/>
        </div>
          <div class="row"> 
         <label class="col-md-2 col-form-label">Phone No</label>
          <input class="col-md-4 form-control" type="text" v-model="phone"/>
        </div>
        </div>
        <div class="row">
          <button class="btn btn-primary" @click="Save"> Save </button> 

        </div>
      </div>
    </div>
    
  </div>
</template>
<script>
import {postTeleDirectory} from "@/core/teleDirectory.api.js"
export default {
  name: 'Add',
  data(){
    return{
      name:null,
      address:null,
      phone:null
    }
  },
  computed: {
    payload(){
      return{
      Name: this.name,
      Address: this.address,
      PhoneNo: this.phone
      }

    }
  },
  methods:{
    async Save(){
      const response = await postTeleDirectory(this.payload);
      if(response.status == 200){
        //
      }
    }

  }
}
</script>
