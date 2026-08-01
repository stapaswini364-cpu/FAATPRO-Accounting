import { useState } from "react";

import AccountSubGroupForm from "./components/AccountSubGroupForm";
import AccountSubGroupList from "./AccountSubGroupList";


export default function AccountSubGroup(){


    const [refresh,setRefresh] = useState(false);


    const [editData,setEditData] = useState(null);




    const handleSuccess = ()=>{

        setRefresh(!refresh);

        setEditData(null);

    };




    return (

        <>


            <AccountSubGroupForm

                editData={editData}

                onSuccess={handleSuccess}

            />



            <AccountSubGroupList

                refresh={refresh}

                onEdit={(data)=>
                    setEditData(data)
                }

            />


        </>

    );

}