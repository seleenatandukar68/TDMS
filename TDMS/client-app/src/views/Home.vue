<template>
  <div class="container">
    <table class="table">
      <thead>
        <tr>
          <th>Name</th>
          <th>Address</th>
          <th>Gender</th>
          <th>Phone No.</th>
          <th> Action </th>
        </tr>
      </thead>
      <tbody v-for="(item,index) in teles" v-bind:key="item.id">
        <tr class="pointer"   v-show="editOffset != index">
          <td>
            {{ item.name }}
          </td>
          <td>
            {{ item.address }}
          </td>
          <td v-if="item.gender == false">
            Male
           
          </td>
            <td v-else>
            Female
           
          </td>
          <td>
            {{ item.phoneNo }}
          </td>
          <td>
            <a href="#" @click.prevent="toggleEdit(item,index)" class="btn btn-md btn-default">
              <svgicon icon="pencil" width="22" height="18" ></svgicon>
          
        </a>
         
          </td>
        </tr>
                <tr class="pointer"  v-show="editOffset == index">
          <td>
            <input type="text" class="form-control" v-model="item.name"/>
           
          </td>
          <td>
            <input type="text" class="form-control" v-model="item.address"/>
          </td>
          <td >
            <div class="row ml-4">
                 <input
                class="form-check-input"
                type="radio"
                name="gendermale"
                value="false"
                :checked="item.gender == false"
                v-model="item.gender"
              />
              <label class="form-check-label" for="gendermale">
                Male {{item.gender}}
              </label>
            </div>
          <div class="row ml-4">
            <input
                class="form-check-input"
                type="radio"
                name="genderFemale"
                value="true"
                checked="item.gender == true"
                v-model="item.gender"
              />
              <label class=" form-check-label" for="genderFemale">
                Female {{item.gender}}
              </label>
          </div>
           
          </td>
          <td>
           <input type="text" class="form-control" v-model="item.phoneNo"/>
          </td>
          <td>
            <a href="#" @click.prevent="Save(item)" class="btn btn-md btn-default">
          
         <svgicon icon="check" width="22" height="18" color="#dc3545"></svgicon>
        </a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
// @ is an alias to /src
import { getTeleDirectory,putTeleDirectory } from "@/core/teleDirectory.api.js";

export default {
  name: "Home",
  data() {
    return {
      teles: [],
      editOffset:-1,
      
  
    };
  },
  mounted() {
    this.fetchUsers();
  },
  computed:{
      
  },
  methods: {
    async fetchUsers() {
      const response = await getTeleDirectory();

      this.teles = response.data;
    },
    toggleEdit (ev,index){
      console.log(ev);
      this.comparisonvalue = ev.gender;
      console.log(this.comparisonvalue);
      this.editOffset = index;
 
        
      },
      async Save(item){
        var data = {
          Id: item.id,
           Name: item.name,
        Address: item.address,
        PhoneNo: item.phoneNo,
        Gender: this.gender}
        const response = await putTeleDirectory(data);
      if (response.status == 200) {
        //
        this.editOffset = -1;
      }
      }
    
  },
};
</script>
