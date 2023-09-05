// this is a wrapper component that will be used to wrap our entire application
'use client'
import React from 'react';
import { Provider } from 'react-redux';
import store from '@/redux/store';

 const ReduxProvider = ({ children }:{children:any}) => {
    return <Provider store={store}>{children}</Provider>;
    };

export default ReduxProvider;