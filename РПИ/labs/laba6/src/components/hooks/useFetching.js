export const useFetching = (callback)=> {
    const fetching=async (...args)=>{
        await callback(...args)
    }
    return fetching
}