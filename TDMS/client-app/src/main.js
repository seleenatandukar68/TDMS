import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import VueSVGIcon from 'vue-svgicon';
import '@/components/icons';
import vuetify from '@/plugins/vuetify.js' ;
import Toasted from 'vue-toasted';
Vue.use(VueSVGIcon)
Vue.use(Toasted)

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
