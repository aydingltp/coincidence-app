<template>
  <!-- Header -->
  <div id="header">

    <!-- Logo -->
    <h1><a href="index.html" id="logo">Dirayettv <em>21. Yüzyılda İslamiyet</em></a></h1>

    <!-- Nav -->
    <nav id="nav">
      <ul>
        <router-link tag="li" to="/Home" active-class="current">
          <a>Anasayfa</a>
        </router-link>
        <li>
          <a>Dropdown</a>
          <ul>
            <li><a href="#">Lorem dolor</a></li>
            <li><a href="#">Magna phasellus</a></li>
            <li><a href="#">Etiam sed tempus</a></li>
            <li>
              <a href="#">Submenu</a>
              <ul>
                <li><a href="#">Lorem dolor</a></li>
                <li><a href="#">Phasellus magna</a></li>
                <li><a href="#">Magna phasellus</a></li>
                <li><a href="#">Etiam nisl</a></li>
                <li><a href="#">Veroeros feugiat</a></li>
              </ul>
            </li>
            <li><a href="#">Veroeros feugiat</a></li>
          </ul>
        </li>

        <router-link to="/LeftSidebar" tag="li" active-class="current">
          <a>Left Sidebar</a>
        </router-link>

        <router-link tag="li" to="/NoSidebar" active-class="current">
          <a>No Sidebar</a>
        </router-link>
        <router-link tag="li" to="/Coincidence" active-class="current">
          <a>Tesadüf Sayacı</a>
        </router-link>

        <router-link tag="li" to="/About" active-class="current">
          <a>Hakkımızda</a>
        </router-link>
        <li><a href="src/TesadufSayaci.html">temayagir</a></li>

      </ul>
    </nav>

  </div>
</template>

<script>
  export default {
    name: "Header"
  }
</script>

<style scoped>

</style>
