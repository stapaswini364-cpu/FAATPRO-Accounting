import { useState } from "react";

import AccountGroupForm from "./components/AccountGroupForm";
import AccountGroupList from "./AccountGroupList";


export default function AccountGroup(){


    const [refresh,setRefresh] = useState(false);


    const [editData,setEditData] = useState(null);




    const handleSuccess = ()=>{

        setRefresh(!refresh);

        setEditData(null);

    };




    return (

        <>


            <AccountGroupForm

                onSuccess={handleSuccess}

                editData={editData}

            />



            <AccountGroupList

                refresh={refresh}

                onEdit={(data)=>
                    setEditData(data)
                }

            />



        </>

    );

}