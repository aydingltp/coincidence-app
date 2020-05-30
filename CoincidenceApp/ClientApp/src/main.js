import Vue from 'vue';
import App from './App.vue';
import {router} from "./router";
//import VueSocketIO from 'vue-socket.io';
//import socketio from 'socket.io';

//export const SocketInstance = 'https://localhost:5001/api/tesaduf';
//
// Vue.use(new VueSocketIO({
//   connection:'https://localhost:5001/api/tesaduf'
// }))

Vue.filter("zaman", (value) => {
  return parseFloat(value).toLocaleString(undefined, {minimumIntegerDigits : 2})
})
new Vue({
  el: '#app',
  render: h => h(App),
  router
}).$mount('#app')
