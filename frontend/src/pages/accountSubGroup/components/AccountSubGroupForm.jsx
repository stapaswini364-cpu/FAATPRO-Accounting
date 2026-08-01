import { useEffect, useState } from "react";

import {
    TextField,
    Button,
    Paper,
    Grid,
    MenuItem,
    Stack
} from "@mui/material";

import accountSubGroupApi from "../../../api/accountSubGroupApi";
import accountHeadApi from "../../../api/accountHeadApi";
import accountGroupApi from "../../../api/accountGroupApi";


const initialForm = {

    accountHeadId: "",
    accountGroupId: "",
    code: "",
    name: "",
    nature: 0,
    displayOrder: 1,
    isActive: true

};



export default function AccountSubGroupForm({
    onSuccess,
    editData
}) {


    const [heads,setHeads] = useState([]);

    const [groups,setGroups] = useState([]);

    const [form,setForm] = useState(initialForm);



    useEffect(()=>{

        loadHeads();
        loadGroups();

    },[]);




    useEffect(()=>{


        if(editData)
        {

            setForm({

                accountHeadId:
                    editData.accountHeadId || "",


                accountGroupId:
                    editData.accountGroupId || "",


                code:
                    editData.code || "",


                name:
                    editData.name || "",


                nature:
                    editData.nature ?? 0,


                displayOrder:
                    editData.displayOrder ?? 1,


                isActive:
                    editData.isActive ?? true

            });

        }
        else
        {

            setForm(initialForm);

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






    const loadGroups = async()=>{


        try
        {

            const data =
                await accountGroupApi.getAll();


            setGroups(

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
                "Account Group Load Error",
                error
            );

        }

    };







    const handleChange=(e)=>{


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


                nature:
                    Number(form.nature),


                displayOrder:
                    Number(form.displayOrder)


            };



            console.log(
                "Account Sub Group Payload",
                payload
            );




            if(editData)
            {

                await accountSubGroupApi.update(

                    editData.id,

                    payload

                );

            }
            else
            {

                await accountSubGroupApi.create(

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

                "Account Sub Group Save Error",

                error.response?.data || error.message

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







                <Grid item xs={12} md={3}>


                    <TextField

                        select

                        fullWidth

                        label="Account Group"

                        name="accountGroupId"

                        value={form.accountGroupId}

                        onChange={handleChange}

                    >


                    {

                        groups.map((group)=>(


                            <MenuItem

                                key={group.id}

                                value={group.id}

                            >

                                {group.name}

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







                <Grid item xs={12} md={2}>


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







                <Grid item xs={12}>


                    <Stack direction="row" spacing={2}>


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