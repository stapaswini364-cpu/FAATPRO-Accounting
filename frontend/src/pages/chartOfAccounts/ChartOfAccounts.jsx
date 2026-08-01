import { useEffect, useState } from "react";

import {
    Paper,
    Typography,
    Box,
    Collapse,
    IconButton,
    List,
    ListItem,
    ListItemText,
    Divider,
    TextField
} from "@mui/material";


import {
    ExpandLess,
    ExpandMore,
    AccountBalance,
    AccountTree,
    AccountBox
} from "@mui/icons-material";


import chartOfAccountsApi from "../../api/chartOfAccountsApi";



export default function ChartOfAccounts(){


    const [data,setData] = useState({

        heads:[],
        groups:[],
        subGroups:[],
        ledgers:[]

    });


    const [openHead,setOpenHead] = useState(null);

    const [openGroup,setOpenGroup] = useState(null);

    const [openSubGroup,setOpenSubGroup] = useState(null);


    const [search,setSearch] = useState("");





    useEffect(()=>{

        loadData();

    },[]);





    const loadData = async()=>{

        try{

            const response =
                await chartOfAccountsApi.getTree();


            setData(response);


        }
        catch(error){

            console.error(
                "Chart Account Error",
                error
            );

        }

    };





    const filteredLedger = (ledger)=>{

        if(!search)

            return true;


        return (

            ledger.name
            ?.toLowerCase()
            .includes(
                search.toLowerCase()
            )

            ||

            ledger.code
            ?.toLowerCase()
            .includes(
                search.toLowerCase()
            )

        );


    };







    return (

        <Paper sx={{p:3}}>


            <Typography

                variant="h5"

                mb={2}

            >

                Chart Of Accounts

            </Typography>





            <TextField

                fullWidth

                label="Search Ledger"

                value={search}

                onChange={
                    e=>setSearch(e.target.value)
                }

                sx={{mb:2}}

            />






            <List>


            {
                data.heads.map(head=>(


                    <Box key={head.id}>


                        <ListItem

                            button

                            onClick={()=>

                                setOpenHead(

                                    openHead===head.id

                                    ?

                                    null

                                    :

                                    head.id

                                )

                            }

                        >


                            <IconButton>

                            {
                                openHead===head.id

                                ?

                                <ExpandLess/>

                                :

                                <ExpandMore/>

                            }

                            </IconButton>



                            <AccountBalance sx={{mr:1}}/>


                            <ListItemText

                                primary={head.name}

                                secondary="Account Head"

                            />


                        </ListItem>





                        <Collapse

                            in={
                                openHead===head.id
                            }

                        >


                        <List sx={{pl:4}}>


                        {
                            data.groups

                            .filter(

                                group=>

                                group.accountHeadId===head.id

                            )

                            .map(group=>(


                                <Box key={group.id}>


                                <ListItem


                                    button


                                    onClick={()=>


                                        setOpenGroup(

                                            openGroup===group.id

                                            ?

                                            null

                                            :

                                            group.id

                                        )


                                    }


                                >


                                <IconButton>

                                {

                                openGroup===group.id

                                ?

                                <ExpandLess/>

                                :

                                <ExpandMore/>

                                }


                                </IconButton>


                                <AccountTree sx={{mr:1}}/>


                                <ListItemText

                                    primary={group.name}

                                    secondary="Account Group"

                                />


                                </ListItem>





                                <Collapse

                                    in={
                                        openGroup===group.id
                                    }

                                >


                                <List sx={{pl:5}}>


                                {

                                data.subGroups

                                .filter(

                                    sub=>

                                    sub.accountGroupId===group.id

                                )

                                .map(sub=>(



                                    <Box key={sub.id}>


                                    <ListItem


                                        button


                                        onClick={()=>


                                        setOpenSubGroup(

                                            openSubGroup===sub.id

                                            ?

                                            null

                                            :

                                            sub.id

                                        )


                                        }


                                    >


                                    <IconButton>

                                    {

                                    openSubGroup===sub.id

                                    ?

                                    <ExpandLess/>

                                    :

                                    <ExpandMore/>

                                    }


                                    </IconButton>



                                    <AccountBox sx={{mr:1}}/>


                                    <ListItemText

                                        primary={sub.name}

                                        secondary="Account Sub Group"

                                    />


                                    </ListItem>





                                    <Collapse

                                        in={

                                            openSubGroup===sub.id

                                        }

                                    >



                                    <List sx={{pl:7}}>


                                    {

                                    data.ledgers

                                    .filter(

                                        ledger=>

                                        ledger.accountSubGroupId===sub.id

                                    )

                                    .filter(filteredLedger)

                                    .map(ledger=>(



                                        <ListItem

                                            key={ledger.id}

                                        >


                                        <ListItemText


                                            primary={

                                                `${ledger.code} - ${ledger.name}`

                                            }


                                            secondary={

                                                `Balance : ${ledger.openingBalance}`

                                            }


                                        />


                                        </ListItem>


                                    ))

                                    }



                                    </List>



                                    </Collapse>


                                    <Divider/>


                                    </Box>


                                ))

                                }



                                </List>



                                </Collapse>


                                </Box>


                            ))

                        }



                        </List>


                        </Collapse>


                    </Box>


                ))
            }



            </List>


        </Paper>

    );

}