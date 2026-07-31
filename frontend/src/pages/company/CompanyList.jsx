import { useEffect, useState } from "react";

import {
    Box,
    Button,
    Paper,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Typography
} from "@mui/material";


import companyApi from "../../api/companyApi";

import CompanyForm from "./components/CompanyForm";



export default function CompanyList()
{

    const [companies, setCompanies] = useState([]);

    const [showForm, setShowForm] = useState(false);

    const [editData, setEditData] = useState(null);





    const loadCompanies = async () => {

        try {

            const data = await companyApi.getAll();

            setCompanies(data);

        }
        catch(error)
        {

            console.error(
                "Company loading failed",
                error
            );

        }

    };





    useEffect(() => {

        loadCompanies();

    }, []);






    const handleEdit = (company)=>{

        setEditData(company);

        setShowForm(true);

    };






    const handleDelete = async(id)=>{


        const confirmDelete =
            window.confirm(
                "Delete this company?"
            );


        if(!confirmDelete)
            return;



        try
        {

            await companyApi.remove(id);


            loadCompanies();


        }
        catch(error)
        {

            console.error(
                "Delete failed",
                error
            );

        }


    };






    const closeForm = ()=>{

        setShowForm(false);

        setEditData(null);

    };







    return (

        <Box>


            <Typography
                variant="h5"
                mb={3}
            >
                Company Master
            </Typography>






            <Button
                variant="contained"
                sx={{
                    mb:2
                }}

                onClick={()=>{
                    setEditData(null);
                    setShowForm(true);
                }}

            >
                Add Company
            </Button>







            {
                showForm && (

                    <Box mb={3}>


                        <CompanyForm

                            editData={editData}


                            onSuccess={()=>{

                                closeForm();

                                loadCompanies();

                            }}

                        />



                        <Button

                            sx={{mt:2}}

                            variant="outlined"

                            onClick={closeForm}

                        >

                            Cancel

                        </Button>


                    </Box>

                )
            }









            <TableContainer component={Paper}>

                <Table>



                    <TableHead>

                        <TableRow>


                            <TableCell>
                                Code
                            </TableCell>



                            <TableCell>
                                Name
                            </TableCell>



                            <TableCell>
                                Active
                            </TableCell>



                            <TableCell>
                                Actions
                            </TableCell>


                        </TableRow>

                    </TableHead>








                    <TableBody>


                    {
                        companies.length > 0

                        ?

                        companies.map((item)=>(


                            <TableRow
                                key={item.id}
                            >



                                <TableCell>
                                    {item.companyCode}
                                </TableCell>




                                <TableCell>
                                    {item.companyName}
                                </TableCell>




                                <TableCell>

                                    {
                                        item.isActive
                                        ?
                                        "Yes"
                                        :
                                        "No"
                                    }

                                </TableCell>




                                <TableCell>


                                    <Button

                                        size="small"

                                        variant="outlined"

                                        sx={{mr:1}}

                                        onClick={()=>handleEdit(item)}

                                    >

                                        Edit

                                    </Button>





                                    <Button

                                        size="small"

                                        color="error"

                                        variant="contained"

                                        onClick={()=>handleDelete(item.id)}

                                    >

                                        Delete

                                    </Button>


                                </TableCell>




                            </TableRow>


                        ))

                        :

                        (

                            <TableRow>

                                <TableCell
                                    colSpan={4}
                                    align="center"
                                >

                                    No Company Found

                                </TableCell>

                            </TableRow>

                        )

                    }


                    </TableBody>



                </Table>

            </TableContainer>



        </Box>

    );

}