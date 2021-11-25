const data = {
    labels: generateLabels(),
    datasets: [
      {
        label: 'Dataset',
        data: generateData(),
        borderColor: Utils.CHART_COLORS.red,
        backgroundColor: Utils.transparentize(Utils.CHART_COLORS.red),
        fill: false
      }
    ]
  };