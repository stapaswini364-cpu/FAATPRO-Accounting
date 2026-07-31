import {
    Drawer,
    List,
    ListItem,
    ListItemButton,
    ListItemIcon,
    ListItemText
} from "@mui/material";


import {
    Dashboard,
    People,
    Business,
    AccountTree,
    Settings
} from "@mui/icons-material";


import { useNavigate } from "react-router-dom";



const menuItems = [

    {
        title: "Dashboard",
        path: "/",
        icon: <Dashboard />
    },


    {
        title: "Customers",
        path: "/customers",
        icon: <People />
    },


    {
        title: "Company",
        path: "/company",
        icon: <Business />
    },


    {
        title: "Branch",
        path: "/branch",
        icon: <AccountTree />
    },


    {
        title: "Settings",
        path: "/settings",
        icon: <Settings />
    }

];




export default function Sidebar()
{


    const navigate = useNavigate();



    return (

        <Drawer

            variant="permanent"

            sx={{

                width:240,

                "& .MuiDrawer-paper":{

                    width:240,

                    boxSizing:"border-box"

                }

            }}

        >


            <List>


                {
                    menuItems.map((item)=>(


                        <ListItem

                            key={item.title}

                            disablePadding

                        >

                            <ListItemButton

                                onClick={()=>navigate(item.path)}

                            >


                                <ListItemIcon>

                                    {item.icon}

                                </ListItemIcon>



                                <ListItemText

                                    primary={item.title}

                                />


                            </ListItemButton>


                        </ListItem>


                    ))

                }


            </List>


        </Drawer>

    );

}