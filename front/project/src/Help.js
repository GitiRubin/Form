import { useSelector } from "react-redux";
import { Link } from 'react-router-dom'

export default function Help() {
     const currUserFirstName = useSelector(state => state.currentUser.firstName)
     const currUserLastName = useSelector(state => state.currentUser.lastName)
     
    return (<div>
        <h1>{!currUserFirstName?"שלום":"שלום ל"+currUserFirstName+" "+currUserLastName}</h1>
        <Link to={'./'}>form</Link>
    </div>)
}