
import { TextField, MenuItem, Button } from "@mui/material"
import {  useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Link } from 'react-router-dom'
import { setCurrentUser, setUserChildren, addChild, setIsAddChild } from "./action";
import { postUser, postChild } from "./apiCalls";
import swal from 'sweetalert';
import { useForm } from "react-hook-form";

import './form.css'



export default function Form() {
    const current = useSelector(state => state.currentUser)
    const currentChild = useSelector(state => state.child)
    const [child, setChild] = useState(currentChild)
    const [user, setUser] = useState(current)
    const dispatch = useDispatch()
    const isAddChild = useSelector(state => state.isAddChild)
    const { register, handleSubmit, formState: { errors } } = useForm();

    const onSubmit = async (data) => {
        console.log(data);
        console.log("good withoutErrors!");
        dispatch({ type: 'setCurrentUser', payload: user })

        if (currentChild.name != "") {
            try {
                const ch = await postChild(currentChild)
            }
            catch (e) {
                console.log('error: ', e)
            }
        }

        try {
            const u = await postUser(user)
            swal("יפה מאד!", " הפרטים נשמרו בהצלחה", "success")
        }
        catch (e) {
            console.log("error: ", e)
        }

    }


    function handleUserChange(e) {

        setUser({ ...user, [e.target.name]: e.target.value })
        dispatch(setCurrentUser({ ...user, [e.target.name]: e.target.value }))
       

    }

    function handleChildChange(e) {
        console.log(currentChild)
        setChild({ ...child, [e.target.name]: e.target.value })
        dispatch(setUserChildren({ ...child, [e.target.name]: e.target.value }))
       


    }


    function handleDate(e) {

        setChild({ ...child, date: e.target.value })
        dispatch(setUserChildren({ ...child, date: e.target.value }))
    }

    function addChildInput() {
        if (current.userId === "")
            alert("עליך למלא קודם כל את פרטיך האישיים!")
        else {
            dispatch(setIsAddChild(true))
            setChild({ ...child, parentId: current.userId })
        }
    }

    async function addNewChild() {

        if (current.firstName === "" || current.lastName === "" || current.userId === "" || current.date === "" || current.type === "" || current.hmo === "" || currentChild.name === "" || currentChild.date === "" || currentChild.childId === "" || currentChild.parentId === "")
            alert("כל השדות הם שדות חובה, נא מלא את כולם!")

        else {
            try {
                const ch = await postChild(currentChild)
            }
            catch (e) {
                console.log('error: ', e)
            }

            dispatch(addChild({ name: "", childId: "", date: "", parentId: "" }))
        }
    }





    return (
        <div>
            <form onSubmit={handleSubmit(onSubmit)}><br />


                <TextField id="outlined-basic" label="שם פרטי" variant="outlined" name="firstName"   {...register("firstName", { required: true })} value={current.firstName} onChange={handleUserChange}>
                </TextField><br />
                {errors.firstName && <span>זהו שדה חובה!</span>}<br />
                <TextField id="outlined-basic" label="שם משפחה" variant="outlined" name="lastName" {...register("lastName", { required: true })} value={current.lastName} onChange={handleUserChange} ></TextField><br />{errors.lastName && <span>זהו שדה חובה!</span>}<br />

                <TextField id="outlined-basic" label="תעודת זהות" variant="outlined" name="userId" {...register("userId", { required: true, maxLength: 9, pattern: /^(?:\d*)$/ })} value={current.userId} onChange={handleUserChange}  ></TextField><br />{errors.userId && <span>זהו שדה חובה ורק עד 9 ספרות בלבד!</span>}<br />
                <TextField id="outlined-basic" type={"date"} variant="outlined" name="date"  {...register("date", { required: true })} value={current.date} onChange={handleUserChange}  ></TextField><br />{errors.date && <span>זהו שדה חובה!</span>}<br /><br />
                <input type={"radio"} name="type" id="z" {...register("type", { required: true })} value="זכר" onChange={handleUserChange} defaultChecked={current.type === "זכר"} /><label for="z">   זכר </label><br /> {errors.type && <span>זהו שדה חובה!</span>}<br /><br />
                <input type={"radio"} name="type" id="n" {...register("type", { required: true })} value="נקבה" onChange={handleUserChange} defaultChecked={current.type === "נקבה"} /><label for="n" >נקבה</label><br /> {errors.type && <span>זהו שדה חובה!</span>}<br /><br />
                <TextField
                    id="outlined-select-currency"
                    select
                    label="קופת חולים"
                    defaultValue={current.hmo}
                    key={"קופת חולים"}
                    name="hmo"
                    onChange={handleUserChange}
                >
                    <MenuItem key={"כללית"} value={"כללית"} selected>
                        כללית
                    </MenuItem>
                    <MenuItem key={"מאוחדת"} value={"מאוחדת"}>
                        מאוחדת
                    </MenuItem><MenuItem key={"מכבי"} value={"מכבי"}>
                        מכבי
                    </MenuItem><MenuItem key={"לאומית"} value={"לאומית"}>
                        לאומית
                    </MenuItem>
                </TextField><br /><br />
                {!isAddChild && <Button variant="text" onClick={() => addChildInput()} >הוסף ילד</Button>}<br />
                {isAddChild && <label>פרטי ילד:</label>}<br /><br />
                {isAddChild && <TextField id="outlined-basic" name="name" value={currentChild.name} label="שם פרטי" variant="outlined" onChange={handleChildChange} />}<br /> <br />
                {isAddChild && <TextField id="outlined-basic" type={"date"} variant="outlined" name="date" value={currentChild.date} onChange={handleDate}  ></TextField>}<br /> <br />
                {isAddChild && <TextField id="outlined-basic" name="childId" label="תעודת זהות" variant="outlined" value={currentChild.childId} onChange={handleChildChange} />}<br /> <br />
                {isAddChild && <Button onClick={() => addNewChild()}>הוסף ילד נוסף</Button>}   <br />

                <Button type="submit">submit</Button>
            </form>

            <Link to={'./help'}>help</Link>

        </div>
    )

}