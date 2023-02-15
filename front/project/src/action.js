export function setCurrentUser(user){
    return {type: 'setCurrentUser', payload: user}
}

export function setUserChildren(child){
    return {type: 'setUserChildren', payload: child}
}


export function addChild(child){
    return {type: 'addChild', payload: child}
}
export function setIsAddChild(flag){
    return {type: 'setIsAddChild', payload: flag}
}