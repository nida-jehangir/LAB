<template>
    <div>
       <div class="form-group">
                <label for="uploadCsvFile">Upload CSV file to find the leader value:</label>
                 <input type="file" id="uploadCsvFile" class="form-control-file" ref="file" @change="selectFile"/>   
            </div>
            <div class="form-group">
                 <button class="btn btn-success" :disabled="!selectedFile" @click="getLeaderValue">Submit File</button>
            </div>
            <div v-if="leaderValue">
                <p>Laeder value in uploaded file is {{ leaderValue }}</p>
            </div>
            <div v-if="message" class="alert alert-danger" role="alert">
                {{message}}
            </div>   
        </div>
</template>

<script>
import {LeaderService} from "../services/Leaderservice";
    export default {
         name: "upload-file",
         data() {
            return {
                selectedFile: undefined,
                leaderValue : undefined,
                message : ''                
            }
         },
         methods: {

            selectFile() {      
                this.selectedFile = this.$refs.file.files[0];    
                },

            async getLeaderValue() {                
                let result = await LeaderService.getLeaderValue(this.selectedFile);
                this.leaderValue = result.leaderValue;
                this.message = result.message;

            }
         },
        
    }
</script>

<style lang="scss" scoped>

</style>