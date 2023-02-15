import axios from "axios";

export  function postUser(u){
    return axios.post('https://localhost:7053/api/User', {userId:u.userId,firstName:u.firstName,lastName:u.lastName,date:u.date,type:u.type,hmo:u.hmo})

}
export  function postChild(c) {
    return axios.post('https://localhost:7053/api/Children', {childId:c.childId,name:c.name,date:c.date,parentId:c.parentId} )
}