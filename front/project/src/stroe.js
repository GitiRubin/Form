import produce from "immer"
import { createStore } from "redux"
const initialState = {
    
    child: {
        name: "",
        childId: "",
        date: "",
        parentId:""
    },
    currentUser: {
        firstName: "",
        lastName: "",
        userId: "",
        date: "",
        type: "",
        hmo: "כללית",
        
    },
    isAddChild:false
   

}

const reducer = produce((state, action) => {
    switch (action.type) {
        case 'setCurrentUser':
            state.currentUser = action.payload
            break
        case 'setUserChildren':
            state.child = action.payload
            break
        case 'addChild':
           { 
            
            
            state.child=action.payload;
           } 
            break
         case 'setIsAddChild':
            state.isAddChild=action.payload
            

    }
}, initialState)
export const s = createStore(reducer, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__())