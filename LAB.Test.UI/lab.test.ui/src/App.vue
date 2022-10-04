<template>
   <div id="app">
    <div class="container">
     <h3>LAB Test</h3>
      <upload-file></upload-file>
    </div>
  </div>
</template>

<script>

import UploadFile from "./components/UploadFile";

export default ({
    name: "App",
    components: {
      UploadFile
       }
})
</script>