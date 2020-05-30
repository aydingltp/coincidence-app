import Vue from "vue";
import Home from "./components/Home";
import LeftSidebar from "./components/LeftSidebar";
import NoSidebar from "./components/NoSidebar";
import Countdown from "./components/shared/Countdown";
import About from "./components/About";
import VueRouter from "vue-router";
import Coincidence from "./components/Coincidence";

Vue.use(VueRouter);

const routes = [
  {path: "/" ,component: Home},
  {path: "/Home" ,component: Home},
  {path: "/LeftSidebar" ,component: LeftSidebar},
  {path: "/NoSidebar" ,component: NoSidebar},
  {path: "/Countdown" ,component: Countdown},
  {path: "/Coincidence" ,component: Coincidence},
  {path: "/About", component: About},
  {path: "*", redirect: "/"}
]
export const router = new VueRouter({
  mode : "history",
  routes
});
