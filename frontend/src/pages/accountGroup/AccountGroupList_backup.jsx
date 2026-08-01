import { useState } from "react";

import AccountGroupForm from "./components/AccountGroupForm";
import AccountGroupList from "./AccountGroupList";


export default function AccountGroup(){


    const [refresh,setRefresh] = useState(false);

    const [editData,setEditData] = useState(null);



    return (

        <>


            <AccountGroupForm

                editData={editData}

                onSuccess={()=>{

                    setEditData(null);

                    setRefresh(!refresh);

                }}

            />



            <AccountGroupList

                refresh={refresh}

                onEdit={(data)=>{

                    setEditData(data);

                }}

            />


        </>

    );

}