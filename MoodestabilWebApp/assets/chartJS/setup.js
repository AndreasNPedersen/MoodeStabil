const inputs = {
    min: -100,
    max: 100,
    count: 8,
    decimals: 2,
    continuity: 1
  };
  
  const generateLabels = () => {
    return Utils.months({count: inputs.count});
  };
  
  const generateData = () => (Utils.numbers(inputs));