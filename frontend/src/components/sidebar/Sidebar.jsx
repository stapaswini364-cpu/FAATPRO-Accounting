import {
  LayoutDashboard,
  Users,
  Settings,
  X
} from "lucide-react";

import { NavLink } from "react-router-dom";


const Sidebar = ({ open, setOpen }) => {


const menuItems = [
  {
    name:"Dashboard",
    path:"/",
    icon:<LayoutDashboard/>
  },
  {
    name:"Customers",
    path:"/customers",
    icon:<Users/>
  },
  {
    name:"Settings",
    path:"/settings",
    icon:<Settings/>
  }
];


return (

<div
className={`
fixed md:static
top-0 left-0
h-screen
w-64
bg-gray-900
text-white
p-5
transition-transform
duration-300
${open ? "translate-x-0" : "-translate-x-full"}
md:translate-x-0
z-50
`}
>


<div className="flex justify-between items-center mb-8">


<h1 className="text-2xl font-bold">
FAATPRO
</h1>


<button
className="md:hidden"
onClick={()=>setOpen(false)}
>

<X/>

</button>


</div>



<nav className="space-y-3">


{
menuItems.map((item)=>(

<NavLink
key={item.path}
to={item.path}
onClick={()=>setOpen(false)}

className={({isActive})=>

`
flex items-center gap-3
p-3
rounded-lg

${
isActive
?
"bg-blue-600"
:
"hover:bg-gray-700"
}

`

}

>

{item.icon}

<span>
{item.name}
</span>


</NavLink>

))
}


</nav>


</div>

)

}


export default Sidebar;