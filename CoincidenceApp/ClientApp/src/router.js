import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {path: "*", redirect: "/"}
]
export const router = new VueRouter({
  mode : "history",
  routes
});
