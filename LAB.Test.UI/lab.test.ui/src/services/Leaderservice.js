import axios from "axios";
import {API} from "../shared/config"
const getLeaderValue = async function(file)
{
    let formData = new FormData();
    formData.append("File", file);
    try
    {
        const response = await axios.post(`${API}leader/FindLeaderValue`,formData, {
            headers: {
                "Content-Type": "multipart/form-data"
            }
        });        
        const leaderValue = {leaderValue : response.data , message : undefined};
        return leaderValue;
    }
    catch (error) {    
    if(error.response.status == 400 && error.response.data)
    {
        return {leaderValue : undefined , message : error.response.data};
    }
    else
    return {leaderValue : undefined , message : "error occured"};
  }
};

export const LeaderService = {
    getLeaderValue,
  }
