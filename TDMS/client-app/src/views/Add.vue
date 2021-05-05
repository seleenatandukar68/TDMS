<template>
  <div class="container container-fluid">
    <div class="card">
      <div class="card-header">
        <div class="row p-3">
          <h4>Add Telephone Details</h4>
        </div>
      </div>
      <div class="card-body">
        <form>
          <div class="form-group">
            <div class="row p-1">
              <label class="col-md-2 col-form-label">Name</label>
              <input class="col-md-4 form-control" type="text" v-model="name" />
            </div>
            <div class="row p-1">
              <label class="col-md-2 col-form-label">Address</label>
              <input
                class="col-md-4 form-control"
                type="text"
                v-model="address"
              />
            </div>
            <div class="row p-1">
              <label class="col-md-2 col-form-label">Phone No</label>
              <input
                class="col-md-4 form-control"
                type="text"
                v-model="phone"
              />
            </div>
            <div class="row p-1">
              <label class="col-md-2 col-form-label">Gender</label>
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="radio"
                  value="false"
                  v-model="gender"
                />
                <label class="form-check-label"> Male </label>
              </div>
              <div class="form-check form-check-inline">
                <input
                  class="form-check-input"
                  type="radio"
                  value="true"
                  v-model="gender"
                />
                <label class="form-check-label"> Female </label>
              </div>
            </div>
            <div class="row">
              <div class="col-md-12 float-right">
                <button class="btn btn-primary" @click.prevent="Save">
                  Save
                </button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
import { postTeleDirectory } from "@/core/teleDirectory.api.js";
export default {
  name: "Add",
  data() {
    return {
      name: null,
      address: null,
      phone: null,
      gender: false,
    };
  },
  computed: {
    payload() {
      return {
        Name: this.name,
        Address: this.address,
        PhoneNo: this.phone,
        Gender: Boolean(this.gender),
      };
    },
  },
  methods: {
    async Save() {
      console.log(this.payload);
      const response = await postTeleDirectory(this.payload);
      if (response.status == 200) {
        //
        this.$toasted.show("Record Added !!", {
          theme: "outline",
          position: "top-center",
          duration: 5000,
          // action: [
          //   {
          //     text: "Cancel",
          //     onClick: (e, toastObject) => {
          //       toastObject.goAway(0);
          //     },
          //   },
          // ],
        });
      }
    },
  },
};
</script>
