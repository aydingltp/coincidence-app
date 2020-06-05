import Vue from 'vue';
import App from './App.vue';
import {router} from "./router";

Vue.filter("zaman", (value) => {
  return parseFloat(value).toLocaleString(undefined, {minimumIntegerDigits : 2})
})
new Vue({
  el: '#app',
  render: h => h(App),
  router
}).$mount('#app')
