'use client'
 import { useProfileQuery } from '@/redux/apiSlice';
 import { useRouter,useParams } from 'next/navigation';
import { useEffect } from 'react';
import Image from 'next/image'
import background from '../../public/background.png'



const Profile = () => {
    
    const router = useRouter();
    const params = useParams();
    const { id } = params;
    const { data, error, isLoading } = useProfileQuery({id});
    useEffect(() => {
        if (data) {
            console.log(data);
        }
    }, [data]);
    return (
        <div className='mt-14 space-y-6 mx-10'>
            <div className="bg-[url('../public/background.png')]"> 
                
            </div>
            
            <img className='mx-auto w-64 h-64 rounded-full border-[6px] z-40 border-purple-600' src={data?.photo} alt="" />
             
            <div className='w-1/2'>
            <div className='flex justify-between items-end'>
                <h1 className=' text-4xl font-bold mt-4'>{data?.fullName}</h1>
                {data && <span className='text-xl'>Addis Ababa University</span>}
            </div>
            <div className='flex justify-between items-center'>
                <p className=' text-2xl mt-4'>Internal Medicine</p>
                {data && <span className='text-xl'>Washington Medical Center</span>}
                
            </div>
            <h3 className='font-bold mt-14 text-2xl'>About</h3>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Blanditiis, recusandae provident vel atque odio tempore hic placeat accusantium quas doloribus fugit minima odit, fuga ipsa harum ullam doloremque neque ut?
            Rem maxime id in dolor quos? Qui numquam blanditiis iure laboriosam facere mollitia sit dolore labore vitae est quasi nisi ipsam doloribus, ipsa ut deleniti doloremque. Vitae ut est asperiores.
            Temporibus, eius nihil tenetur voluptatum inventore facilis quo! Magnam voluptatem dolore autem et, iure nam nostrum aperiam quas delectus dolorem, voluptate eius doloribus corporis maiores quidem omnis ipsam, expedita corrupti.</p>
            <h3 className='font-bold mt-14 text-2xl mb-10'>Education</h3>
            <div className='flex items-start justify-between mb-8'>
                <h4 className='font-bold text-2xl'>Addis Ababa University</h4>
                <p className='text-gray-400 text-xl'>2015-2021</p>
            </div>
            <div className='flex items-start justify-between'>
                <h4 className='font-bold text-2xl'>Bahir dar University</h4>
                <p className='text-gray-400 text-xl'>2015-2021</p>
            </div>
            <h3 className='font-bold mt-14 text-2xl mb-10'>Contact info</h3>
            <p>Lorem ipsum dolor sit amet consectetur, adipisicing elit. Maxime accusamus unde ad quo ratione nemo quaerat praesentium odio vel iste, exercitationem ut voluptatem consectetur rerum illum ullam nihil molestias animi.</p>
        
            </div>
            
            <button onClick={() => router.back()}>Back</button>
            </div>
    );
}

export default Profile;