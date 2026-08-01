import { useEffect, useState } from "react";

import {
    Paper,
    Grid,
    TextField,
    Button,
    MenuItem,
    Stack,
    FormControlLabel,
    Checkbox
} from "@mui/material";


import ledgerApi from "../../api/ledgerApi";
import accountHeadApi from "../../api/accountHeadApi";
import accountGroupApi from "../../api/accountGroupApi";
import accountSubGroupApi from "../../api/accountSubGroupApi";


const initialForm = {

    accountHeadId: "",
    accountGroupId: "",
    accountSubGroupId: "",

    code: "",
    name: "",

    openingBalance: 0,

    balanceType: 0,

    address: "",
    mobile: "",
    email: "",
    gstin: "",

    isActive: true

};



export default function LedgerForm({

    editData,

    onSuccess

}) {


    const [form,setForm] = useState(initialForm);


    const [accountHeads,setAccountHeads] = useState([]);

    const [accountGroups,setAccountGroups] = useState([]);

    const [accountSubGroups,setAccountSubGroups] = useState([]);





    useEffect(()=>{

        loadMasters();

    },[]);





    const loadMasters = async()=>{

        try{


            const heads =
                await accountHeadApi.getAll();


            const groups =
                await accountGroupApi.getAll();


            const subGroups =
                await accountSubGroupApi.getAll();



            console.log(
                "ACCOUNT HEADS",
                heads
            );


            console.log(
                "ACCOUNT GROUPS",
                groups
            );


            console.log(
                "ACCOUNT SUB GROUPS",
                subGroups
            );




            setAccountHeads(

                Array.isArray(heads)

                ?

                heads

                :

                []

            );



            setAccountGroups(

                Array.isArray(groups)

                ?

                groups

                :

                []

            );



            setAccountSubGroups(

                Array.isArray(subGroups)

                ?

                subGroups

                :

                []

            );


        }
        catch(error){

            console.error(
                "Master Load Error",
                error
            );

        }

    };









    useEffect(()=>{


        if(editData){


            setForm({

                accountHeadId:
                    editData.accountHeadId || "",


                accountGroupId:
                    editData.accountGroupId || "",


                accountSubGroupId:
                    editData.accountSubGroupId || "",


                code:
                    editData.code || "",


                name:
                    editData.name || "",


                openingBalance:
                    editData.openingBalance ?? 0,


                balanceType:
                    editData.balanceType ?? 0,


                address:
                    editData.address || "",


                mobile:
                    editData.mobile || "",


                email:
                    editData.email || "",


                gstin:
                    editData.gstin || "",


                isActive:
                    editData.isActive ?? true

            });


        }
        else{

            setForm(initialForm);

        }


    },[editData]);









    const handleChange=(e)=>{


        setForm({

            ...form,

            [e.target.name]:

                e.target.value

        });


    };









    const save = async()=>{


        try{


            const payload = {


                ...form,


                accountSubGroupId:

                    form.accountSubGroupId === ""

                    ?

                    null

                    :

                    form.accountSubGroupId,



                openingBalance:

                    Number(form.openingBalance),



                balanceType:

                    Number(form.balanceType)


            };



            console.log(
                "LEDGER PAYLOAD",
                payload
            );





            if(editData){


                await ledgerApi.update(

                    editData.id,

                    payload

                );


            }

            else{


                await ledgerApi.create(

                    payload

                );


            }




            setForm(initialForm);



            if(onSuccess)

                onSuccess();


        }

        catch(error){


            console.error(

                "Ledger Save Error",

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

                        value={form.accountHeadId || ""}

                        onChange={handleChange}

                    >


                        <MenuItem value="">
                            Select Account Head
                        </MenuItem>



                        {

                            accountHeads.map(item=>(

                                <MenuItem

                                    key={item.id}

                                    value={item.id}

                                >

                                    {item.name}

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

                        value={form.accountGroupId || ""}

                        onChange={handleChange}

                    >


                        <MenuItem value="">
                            Select Account Group
                        </MenuItem>


                        {

                            accountGroups.map(item=>(

                                <MenuItem

                                    key={item.id}

                                    value={item.id}

                                >

                                    {item.name}

                                </MenuItem>


                            ))

                        }


                    </TextField>


                </Grid>









                <Grid item xs={12} md={3}>


                    <TextField

                        select

                        fullWidth

                        label="Account Sub Group"

                        name="accountSubGroupId"

                        value={form.accountSubGroupId || ""}

                        onChange={handleChange}

                    >


                        <MenuItem value="">
                            None
                        </MenuItem>



                        {

                            accountSubGroups.map(item=>(

                                <MenuItem

                                    key={item.id}

                                    value={item.id}

                                >

                                    {item.name}

                                </MenuItem>

                            ))

                        }


                    </TextField>


                </Grid>








                <Grid item xs={12} md={3}>

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

                        label="Ledger Name"

                        name="name"

                        value={form.name}

                        onChange={handleChange}

                    />

                </Grid>








                <Grid item xs={12} md={3}>

                    <TextField

                        fullWidth

                        label="Opening Balance"

                        name="openingBalance"

                        value={form.openingBalance}

                        onChange={handleChange}

                    />

                </Grid>








                <Grid item xs={12} md={3}>

                    <TextField

                        select

                        fullWidth

                        label="Balance Type"

                        name="balanceType"

                        value={form.balanceType}

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









                <Grid item xs={12} md={3}>

                    <TextField

                        fullWidth

                        label="Address"

                        name="address"

                        value={form.address}

                        onChange={handleChange}

                    />

                </Grid>








                <Grid item xs={12} md={3}>

                    <TextField

                        fullWidth

                        label="Mobile"

                        name="mobile"

                        value={form.mobile}

                        onChange={handleChange}

                    />

                </Grid>








                <Grid item xs={12} md={3}>

                    <TextField

                        fullWidth

                        label="Email"

                        name="email"

                        value={form.email}

                        onChange={handleChange}

                    />

                </Grid>








                <Grid item xs={12} md={3}>

                    <TextField

                        fullWidth

                        label="GSTIN"

                        name="gstin"

                        value={form.gstin}

                        onChange={handleChange}

                    />

                </Grid>









                <Grid item xs={12}>


                    <FormControlLabel

                        control={

                            <Checkbox

                                checked={form.isActive}

                                onChange={(e)=>

                                    setForm({

                                        ...form,

                                        isActive:
                                            e.target.checked

                                    })

                                }

                            />

                        }

                        label="Active"

                    />


                </Grid>








                <Grid item xs={12}>


                    <Stack direction="row">


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