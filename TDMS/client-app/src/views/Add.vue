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
              <label class="col-md-2 col-form-label"
                >Name <span class="text-danger">*</span></label
              >
              <input
                class="col-md-4 form-control"
                type="text"
                v-model.trim="$v.name.$model"
                @change="$v.name.$touch"
              />
              <div class="col-md-6">
                <div
                  class="text-danger"
                  v-if="!$v.name.required && $v.name.$dirty"
                >
                  Name is required
                </div>
                <div
                  class="text-danger"
                  v-if="!$v.name.minLength && $v.name.$dirty"
                >
                  Name must have at least
                  {{ $v.name.$params.minLength.min }} letters.
                </div>
              </div>
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
                v-model="$v.phone.$model"
                @change="$v.phone.$touch"
              />
              <div class="col-md-6">
                <div
                  class="text-danger"
                  v-if="!$v.phone.required && $v.phone.$dirty"
                >
                  Phone is required
                </div>
                <div
                  class="text-danger"
                  v-if="!$v.phone.isValidPh && $v.phone.$dirty"
                >
                  Phone number isn't valid
                </div>
              </div>
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
import { validationMixin } from "vuelidate";
import { required, minLength } from "vuelidate/lib/validators";
export default {
  mixins: [validationMixin],
  name: "Add",
  data() {
    return {
      name: null,
      address: null,
      phone: null,
      gender: "false",
    };
  },
  validations: {
    name: {
      required,
      minLength: minLength(4),
    },
    phone: {
      required,
      isValidPh(phone) {
        return /^\D*0(\D*\d){9}\D*$/.test(phone);
      },
    },
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
      // this.$v.$touch();
      //console.log(this.payload);
      if (!this.$v.$invalid) {
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
          this.$router.push("Home");
        }
      }
    },
  },
};
</script>
