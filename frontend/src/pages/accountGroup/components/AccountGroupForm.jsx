import { useEffect, useState } from "react";

import {
    TextField,
    Button,
    Paper,
    Grid,
    MenuItem,
    Stack
} from "@mui/material";

import accountGroupApi from "../../../api/accountGroupApi";
import accountHeadApi from "../../../api/accountHeadApi";


const initialForm = {

    accountHeadId:"",
    code:"",
    name:"",
    nature:0,
    displayOrder:1,
    isActive:true

};



export default function AccountGroupForm({ 
    onSuccess,
    editData
}) {


    const [heads,setHeads] = useState([]);


    const [form,setForm] = useState(initialForm);



    useEffect(()=>{

        loadHeads();

    },[]);





    useEffect(()=>{


        if(editData)
        {

            setForm({

                accountHeadId:
                    editData.accountHeadId || "",

                code:
                    editData.code,

                name:
                    editData.name,

                nature:
                    editData.nature,

                displayOrder:
                    editData.displayOrder,

                isActive:
                    editData.isActive

            });

        }


    },[editData]);







    const loadHeads = async()=>{

        try
        {

            const data =
                await accountHeadApi.getAll();


            setHeads(
                Array.isArray(data)
                ?
                data
                :
                []
            );

        }
        catch(error)
        {

            console.error(
                "Account Head Load Error",
                error
            );

        }

    };







    const handleChange = (e)=>{


        setForm({

            ...form,

            [e.target.name]:
                e.target.value

        });


    };









    const save = async()=>{


        try
        {


            const payload = {

                ...form,

                displayOrder:
                    Number(form.displayOrder),

                nature:
                    Number(form.nature)

            };



            if(editData)
            {


                await accountGroupApi.update(

                    editData.id,

                    payload

                );


            }
            else
            {


                await accountGroupApi.create(
                    payload
                );


            }





            setForm(initialForm);



            if(onSuccess)
                onSuccess();


        }
        catch(error)
        {

            console.error(
                "Account Group Save Error",
                error
            );

        }


    };








    return (

        <Paper sx={{p:3,mb:3}}>


            <Grid container spacing={2}>


                <Grid item xs={12} md={3}>


                    <TextField

                        select

                        fullWidth

                        label="Account Head"

                        name="accountHeadId"

                        value={form.accountHeadId}

                        onChange={handleChange}

                    >


                        {
                            heads.map((head)=>(


                                <MenuItem

                                    key={head.id}

                                    value={head.id}

                                >

                                    {head.name}

                                </MenuItem>


                            ))
                        }


                    </TextField>


                </Grid>





                <Grid item xs={12} md={2}>


                    <TextField

                        fullWidth

                        label="Code"

                        name="code"

                        value={form.code}

                        onChange={handleChange}

                    />


                </Grid>





                <Grid item xs={12} md={3}>


                    <TextField

                        fullWidth

                        label="Name"

                        name="name"

                        value={form.name}

                        onChange={handleChange}

                    />


                </Grid>





                <Grid item xs={12} md={2}>


                    <TextField

                        select

                        fullWidth

                        label="Nature"

                        name="nature"

                        value={form.nature}

                        onChange={handleChange}

                    >

                        <MenuItem value={0}>
                            Debit
                        </MenuItem>


                        <MenuItem value={1}>
                            Credit
                        </MenuItem>


                    </TextField>


                </Grid>





                <Grid item xs={12} md={2}>


                    <Stack spacing={1}>


                        <Button

                            variant="contained"

                            onClick={save}

                        >

                            {
                                editData
                                ?
                                "Update"
                                :
                                "Save"
                            }

                        </Button>


                    </Stack>


                </Grid>



            </Grid>


        </Paper>

    );

}