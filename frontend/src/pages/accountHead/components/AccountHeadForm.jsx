import { useState } from "react";

import {
    Box,
    Button,
    Paper,
    TextField,
    Typography,
    MenuItem
} from "@mui/material";


import accountHeadApi from "../../../api/accountHeadApi";



const initialForm = {

    code: "",
    name: "",
    nature: 0,
    displayOrder: 0,
    isSystem: false,
    isActive: true

};




export default function AccountHeadForm({
    onSuccess
})
{


    const [form,setForm] = useState(initialForm);




    const handleChange = (e)=>{

        const {
            name,
            value
        } = e.target;


        setForm({

            ...form,

            [name]: value

        });

    };






    const handleSubmit = async(e)=>{

        e.preventDefault();


        try
        {

            await accountHeadApi.create(form);


            setForm(initialForm);


            if(onSuccess)
                onSuccess();


        }
        catch(error)
        {

            console.error(
                "Account Head Save Error",
                error.response?.data || error.message
            );

        }

    };






    return (

        <Paper sx={{p:3,mb:3}}>


            <Typography

                variant="h6"

                mb={2}

            >
                Create Account Head

            </Typography>





            <Box

                component="form"

                onSubmit={handleSubmit}

                sx={{

                    display:"grid",

                    gap:2

                }}

            >



                <TextField

                    label="Code"

                    name="code"

                    value={form.code}

                    onChange={handleChange}

                    required

                />





                <TextField

                    label="Name"

                    name="name"

                    value={form.name}

                    onChange={handleChange}

                    required

                />





                <TextField

                    select

                    label="Nature"

                    name="nature"

                    value={form.nature}

                    onChange={handleChange}

                >

                    <MenuItem value={0}>
                        Assets
                    </MenuItem>


                    <MenuItem value={1}>
                        Liability
                    </MenuItem>


                    <MenuItem value={2}>
                        Income
                    </MenuItem>


                    <MenuItem value={3}>
                        Expense
                    </MenuItem>


                </TextField>






                <TextField

                    label="Display Order"

                    name="displayOrder"

                    type="number"

                    value={form.displayOrder}

                    onChange={handleChange}

                />






                <Button

                    variant="contained"

                    type="submit"

                >

                    Save Account Head

                </Button>



            </Box>


        </Paper>

    );

}