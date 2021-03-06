﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using Microsoft.Health.Fhir.Core.Features.Persistence;
using Microsoft.Health.Fhir.SqlServer.Features.Schema.Model;

namespace Microsoft.Health.Fhir.SqlServer.Features.Storage.TvpRowGeneration
{
    internal class ResourceWriteClaimRowGenerator : ITableValuedParameterRowGenerator<ResourceWrapper, V1.ResourceWriteClaimTableTypeRow>
    {
        private readonly SqlServerFhirModel _model;

        public ResourceWriteClaimRowGenerator(SqlServerFhirModel model)
        {
            EnsureArg.IsNotNull(model, nameof(model));
            _model = model;
        }

        public IEnumerable<V1.ResourceWriteClaimTableTypeRow> GenerateRows(ResourceWrapper resource)
        {
            return resource.LastModifiedClaims?.Select(c =>
                new V1.ResourceWriteClaimTableTypeRow(_model.GetClaimTypeId(c.Key), c.Value));
        }
    }
}
